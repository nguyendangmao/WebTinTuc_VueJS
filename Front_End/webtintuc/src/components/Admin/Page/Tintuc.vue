<template>
  <div class="table_scrollbar">
    <table class="table table-bordered" style="width: 2005px; max-width:2005px">
      <thead>
        <tr>
          <th>{{ $t("ID") }}</th>
          <th>{{ $t("Name") }}</th>
          <th>{{ $t("NT") }}</th>
          <th>{{ $t("TL") }}</th>
          <th>{{ $t("QC") }}</th>
          <th>{{ $t("ND") }}</th>
          <th style="text-align: center">{{ $t("Anh") }}</th>
          <th>{{ $t("SoSao") }}</th>
          <th>{{ $t("LuotXem") }}</th>
          <th style="text-align: center">{{$t("DateUpdate")}}</th>
          <th>{{$t("AccUpdate")}}</th>
          <th>{{ $t("More") }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="data in datas" :key="data.id">
          <td>{{ data.idBaiViet }}</td>
          <td>{{ data.tenBaiViet }}</td>
          <td>{{ data.tenNhomTin }}</td>
          <td>{{ data.tenTheLoai }}</td>
          <td>{{data.quangCao}}</td>
          <td><button class="button-6" @click="show(data.idBaiViet)">Xem chi tiết</button></td>
          <td ><img v-bind:src="data.hinhAnh" alt="" style=" width:200px"></td>
          <td style="text-align: center">{{ data.soSaoTB }}</td>
          <td>{{ data.luotXem }}</td>
          <td style="text-align: center">{{ format_date(data.ngaySua) }}</td>
          <td>{{ data.nguoiSua }}</td>
          <td>
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
      LinkAnh:'',
    };
  },
  created: function () {
    this.List();
    
  },
  methods: {
    show(value){
      console.log(value);
    },
    List() {
      try {
        axios.get("https://localhost:44309/api/BaiViet").then((response) => {
          this.datas = response.data;
          console.log(this.datas["anh"]);
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
    getlink(value){
      return value.tostring();
    }
  },
};
</script>