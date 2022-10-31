<template>
  <div>
    <table class="table table-bordered" style="width: 100%">
      <thead>
        <tr>
          <th>{{ $t("ID") }}</th>
          <th>{{ $t("Name") }}</th>
          <th style="text-align: center">{{$t("DateUpdate")}}</th>
          <th>{{$t("AccUpdate")}}</th>
          <th>{{ $t("More") }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="data in datas" :key="data.idTheLoai">
          <td>{{ data.idTheLoai }}</td>
          <td style="">{{ data.tenTheLoai }}</td>
          <td style="text-align: center">{{ format_date(data.ngaySua ) }}</td>
          <td>{{ data.nguoiSua }}</td>
          <td style="width: 25%">
            <button class="button-6">Sửa</button>
            <button class="button-6">Tắt Trạng Thái</button>
            <button class="button-6">Xóa</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";

export default {
  data() {
    return {
      datas: [],
    };
  },
  created: function () {
    this.List();
  },
  methods: {
    List() {
      try {
        axios.get("https://localhost:44309/api/TheLoaiAPI").then((response) => {
           this.datas = response.data.data;
          console.log(this.datas);
        });
      } catch (error) {
        console.log(error);
      }
    },
    format_date(value) {
      try {
        if (value) {
          return moment(String(value)).format("DD-MM-YYYY");
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>