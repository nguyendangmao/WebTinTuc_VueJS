<template>
 <div class="table_scrollbar">
    <table class="table table-bordered" style="width: 2000px ;max-width: 2000px;"  >
      <thead>
        <tr>
          <th>{{ $t("ID") }}</th>
          <th>Quyền</th>
          <th>{{$t("TaiKhoan")}}</th>
          <th>{{$t("MatKhau")}}</th>
          <th>{{ $t("Name") }}</th>
          <th style="text-align: center">{{$t("GioiTinh")}}</th>
          <th>{{$t("SDT")}}</th>
          <th style="text-align: center">{{$t("DateUpdate")}}</th>
          <th>{{$t("AccUpdate")}}</th>
          <th>{{ $t("More") }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="data in datas" :key="data.id">
          <td>{{ data.id }}</td>
          <td>{{ data.tenQuyen }}</td>
          <td>{{ data.tenTk }}</td>
          <td>{{ data.matKhau }}</td>
          <td>{{ data.hoTen }}</td>
          <td style="text-align: center">{{ data.gioiTinh }}</td>
          <td>{{ data.sdt }}</td>
          <td style="text-align: center">{{ format_date(data.ngaySua )}}</td>
          <td>{{ data.nguoiSua }}</td>
          <td >
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
        axios.get("https://localhost:44309/api/NguoiDung").then((response) => {
          this.datas = response.data;
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