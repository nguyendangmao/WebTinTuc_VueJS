<template>
  <Header />
  <Nav />
  <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
    <div class="row">
      <ol class="breadcrumb">
        <li>
          <a href="#">
            <em class="fa fa-home"></em>
          </a>
        </li>
        <li class="active">Nhóm Tin</li>
      </ol>
    </div>
    <!--/.row-->
    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header" style="color: white; margin-bottom: 0px">
          Nhóm Tin
        </h1>
      </div>
    </div>
    <!--/.row-->
    <div>
      <button
        class="button-6"
        style="float: right; margin-bottom: 20px"
        @click="AddOrEdit()"
      >
        Thêm mới
      </button>
      <table class="table table-bordered" style="width: 100%">
        <thead>
          <tr>
            <th>{{ $t("ID") }}</th>
            <th>{{ $t("Name") }}</th>
            <th style="text-align: center">{{ $t("Tabindex") }}</th>
            <th style="text-align: center">{{ $t("DateUpdate") }}</th>
            <th>{{ $t("AccUpdate") }}</th>
            <th>{{ $t("More") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="data in datas" :key="data.idNhomTin">
            <td>{{ data.idNhomTin }}</td>
            <td style="">{{ data.tenNhomTin }}</td>
            <td style="text-align: center">{{ data.thuTuHienThi }}</td>
            <td style="text-align: center">{{ format_date(data.ngaySua) }}</td>
            <td>{{ data.nguoiSua }}</td>
            <td style="width: 25%">
              <button class="button-6" @click="AddOrEdit(data.idNhomTin)">
                Sửa
              </button>
              <button class="button-6">Tắt Trạng Thái</button>
              <button class="button-8" @click="Check_Delete(data.idNhomTin)">
                Xóa
              </button>
            </td>
          </tr>
        </tbody>
      </table>
      <!--Dialog thêm(sửa)-->
      <div v-if="showdialog" class="pop">
        <div class="abc" style="width: 550px">
          <label
            for="tentl"
            style="
              color: black;
              font-size: 30px;
              margin-left: 5px;
              margin-top: 10px;
            "
            >Tên thể loại</label
          >

          <div>
            <input
              style="margin-left: 5px"
              ref="labelInput"
              type="text"
              v-model="this.data.tenNhomTin"
              name="firstname"
              placeholder="Tên thể loại.."
            />
          </div>
          <label
            for="tentl"
            style="
              color: black;
              font-size: 30px;
              margin-left: 5px;
              margin-top: 10px;
            "
            >Thứ tự hiển thị</label
          >
          <div>
            <input
              style="margin-left: 5px"
              ref="labelInput"
              type="text"
              v-model="this.data.thuTuHienThi"
              name="firstname"
              placeholder="Thứ tự hiển thị.."
            />
          </div>
          <button @click="Confim(this.data.idNhomTin)" class="button-8">
            OK
          </button>
          <button @click="Begin()" class="button-8">Hủy</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
import Header from "../Layout/Header.vue";
import Nav from "../Layout//Nav.vue";
export default {
  components: {
    Header,
    Nav,
  },
  data() {
    return {
      datas: [],
      data: {
        idNhomTin: "",
        tenNhomTin: "",
        thuTuHienThi: "",
        ngayTao: "2022-11-02T14:28:37.796Z",
        nguoiTao: "",
        ngaySua: "2022-11-02T14:28:37.796Z",
        nguoiSua: "",
      },
      back_up: {
        idNhomTin: "",
        tenNhomTin: "",
        thuTuHienThi: "",
        ngayTao: "2022-11-02T14:28:37.796Z",
        nguoiTao: "",
        ngaySua: "2022-11-02T14:28:37.796Z",
        nguoiSua: "",
      },
      showdialog: false,
      showtable: true,
    };
  },
  created: function () {
    this.List();
  },

  mounted() {
    let user = localStorage.getItem("user-info");
    if (!user) {
      this.$router.push({ path: "/" });
    }
  },
  methods: {
    /**
     * Get dữ liệu
     * Date:2-11-2022
     * Author: Lợn Cọc
     */
    List() {
      try {
        axios.get("https://localhost:44309/api/NhomTinAPI").then((response) => {
          this.datas = response.data;
        });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Format Ngày
     * Date:2-11-2022
     * Author: Lợn Cọc
     */
    format_date(value) {
      try {
        if (value) {
          return moment(String(value)).format("DD-MM-YYYY");
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Check trước khi xóa
     * Date: 2-11-2022
     * Author:Lợn Cọc
     */
    Check_Delete(id) {
      try {
        axios
          .get("https://localhost:44309/api/Check_Delete/Check_NhomTin/" + id)
          .then((response) => {
            if (response.data.length == 0) {
              if (confirm("Bạn chắc chắn muốn xóa?") == true) {
                axios
                  .delete("https://localhost:44309/api/NhomTinAPI/" + id)
                  .then(() => {
                    alert("Xóa thành công");
                    this.List();
                  });
              }
            } else
              alert("Thể loại này tồn tại bài viết, Chỉ có thể tắt trạng thái");
          });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Check xem
     * Date: 2-11-2022
     * Author:Lợn Cọc
     */
    AddOrEdit(value) {
      this.showdialog = true;
      if (value != null) {
        axios
          .get("https://localhost:44309/api/NhomTinAPI/" + value)
          .then((response) => {
            this.data = response.data;
          });
      }
    },
    /**
     * Ấn nút ok
     * Date: 2-11-2022
     * Author: Lợn Cọc
     */
    Confim(value) {
      if (value == "") {
        this.Add();
      } else {
        this.Edit(value);
      }
    },
    /**
     * Xử lí sự kiện sửa
     * Date:2-11-2022
     * Author: Lợn Cọc
     */
    Edit(value) {
      axios
        .get("https://localhost:44309/api/NhomTinAPI/" + value)
        .then((response) => {
          if (
            response.data.tenNhomTin == this.data.tenNhomTin &&
            response.data.thuTuHienThi == this.data.thuTuHienThi
          ) {
            console.log("A");
          } else {
            axios
              .put("https://localhost:44309/api/NhomTinAPI/" + value, this.data)
              .then(() => {
                alert("Sửa thành công");
                this.List();
              });
          }
          this.Begin();
        });
    },
    /**
     * Xử lí sự kiện thêm
     * Date:2-11-2022
     * Author: Lợn Cọc
     */
    Add() {
      axios
        .post("https://localhost:44309/api/NhomTinAPI/", this.data)
        .then(() => {
          alert("Thêm thành công");
          this.Begin();
          this.List();
        });
      console.log(this.data);
    },
    /**
     * Khởi tạo lại trang thêm hoặc sửa
     * Date:2-11-2022
     * Author: Lợn Cọc
     */
    Begin() {
      this.showdialog = false;
      this.data = this.back_up;
    },
  },
};
</script>