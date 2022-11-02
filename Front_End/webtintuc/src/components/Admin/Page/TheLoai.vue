<template>
  <div  style=" height: 600px;">
    <table class="table table-bordered" style="width: 100%; height: 600px;">
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
            <button class="button-6" @click="AddOrEdit(data.idTheLoai)">Sửa</button>
            <button class="button-6">Tắt Trạng Thái</button>
            <button class="button-6" @click="Check_Delete(data.idTheLoai)">Xóa</button>
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
      check_datas:[],
    };
  },
  created: function () {
    this.List();
  },
  methods: {
    List() {
      try {
        axios.get("https://localhost:44309/api/TheLoaiAPI").then((response) => {
           this.datas = response.data;
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
    Check_Delete(id){
      try {
        axios.get("https://localhost:44309/api/Check_Delete/Check_TheLoai/"+id).then((response) => {
           if(response.data.length == 0){
            if(confirm("Bạn chắc chắn muốn xóa?") == true){
              //Gọi phương thức xóa
            }
           }else alert("Thể loại này tồn tại bài viết, Chỉ có thể tắt trạng thái");
        });
      } catch (error) {
        console.log(error)
      }
    },
    AddOrEdit(value){
      if(value==null){
        alert("Thêm");
      }else alert("Sửa");
    }
  },
};
</script>