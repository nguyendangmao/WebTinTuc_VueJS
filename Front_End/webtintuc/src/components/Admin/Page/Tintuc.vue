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
        <li class="active">Bài Viết</li>
      </ol>
    </div>
    <!--/.row-->
    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header" style="color: white; margin-bottom: 0px">
          Bài Viết
        </h1>
      </div>
    </div>
    <!--/.row-->
    <button class="button-6" style="margin-bottom: 20px" @click="AddOrEdit()">
      Thêm mới
    </button>
    <div class="table_scrollbar">
      <table
        class="table table-bordered"
        style="width: 2005px; max-width: 2005px"
      >
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
            <th style="text-align: center">{{ $t("DateUpdate") }}</th>
            <th>{{ $t("AccUpdate") }}</th>
            <th>{{ $t("More") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="data in datas" :key="data.id">
            <td>{{ data.idBaiViet }}</td>
            <td>{{ data.tenBaiViet }}</td>
            <td>{{ data.tenNhomTin }}</td>
            <td>{{ data.tenTheLoai }}</td>
            <td>{{ data.quangCao }}</td>
            <td>
              <button class="button-6" @click="show(data.noiDungBaiViet)">
                Xem chi tiết
              </button>
            </td>
            <td>
              <img v-bind:src="data.hinhAnh" alt="" style="width: 200px" />
            </td>
            <td style="text-align: center">{{ data.soSaoTB }}</td>
            <td>{{ data.luotXem }}</td>
            <td style="text-align: center">{{ format_date(data.ngaySua) }}</td>
            <td>{{ data.nguoiSua }}</td>
            <td>
              <button class="button-6" @click="AddOrEdit(data.idBaiViet)">
                Sửa
              </button>
              <button class="button-6">Tắt Trạng Thái</button>
              <button class="button-6" @click="Delete(data.idBaiViet)">
                Xóa
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <!--Hiển bài viết-->
    <div v-if="showdetail" class="pop">
      <div
        class="abc demo h-scrollbar"
        v-html="content"
        v-click-away="Close"
      ></div>
    </div>
    <!-- Hiển thị dialog -->
    <div v-if="showdialog" class="pop">
      <div class="abc demo">
        <div style="display: flex">
          <div style="padding-right: 10px">
            <label for="tentl" class="LonCoc" style="margin-bottom: 13px"
              >Nhóm Tin</label
            >
            <select @change="LayNhomTin($event)" v-model="c">
              <option value="null2" disabled>{{ data.tenNhomTin }}</option>
              <option
                v-for="data2 in datas2"
                :key="data2.idNhomTin"
                :value="data2.idNhomTin"
              >
                {{ data2.tenNhomTin }}
              </option>
            </select>
          </div>
          <div style="padding-right: 10px; padding-bottom: 15px">
            <label for="tentl" class="LonCoc" style="margin-bottom: 13px"
              >Thể Loại</label
            >
            <select @change="LayTheLoai($event)" v-model="b">
              <option value="null1" disabled>{{ data.tenTheLoai }}</option>
              <option
                v-for="data3 in datas3"
                :key="data3.idTheLoai"
                :value="data3.idTheLoai"
              >
                {{ data3.tenTheLoai }}
              </option>
            </select>
          </div>
        </div>
        <div style="display: flex">
          <div style="padding-right: 10px; padding-bottom: 15px">
            <label for="tentl" class="LonCoc" style="margin-bottom: 13px"
              >Quảng Cáo</label
            >
            <select @change="LayQuangCao($event)" v-model="a">
              <option value="null" disabled>{{ data.quangCao }}</option>
              <option
                v-for="data1 in datas1"
                :key="data1.idQuangCao"
                :value="data1.idQuangCao"
              >
                {{ data1.noiDungQC }}
              </option>
            </select>
          </div>
          <div>
            <label for="tentl" class="LonCoc">Tên Bài Viết</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              v-model="data.tenBaiViet"
              placeholder="Tên bài viết.."
            />
          </div>
        </div>
        <div style="display: flex">
          <div style="padding-right: 10px; padding-bottom: 15px">
            <label for="tentl" class="LonCoc">Ảnh</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              v-model="data.hinhAnh"
              placeholder="Hình ảnh.."
            />
          </div>
        </div>
        <div id="editor">
          <label for="tentl" class="LonCoc">Nội Dung Bài Viết</label>
          <br />
          <ckeditor :editor="editor" v-model="data.noiDungBaiViet"></ckeditor>
        </div>
        <div style="float: right">
          <button @click="Confim(this.data_export.idBaiViet)" class="button-7">
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
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
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
      content: "",
      showdialog: false,
      showdetail: false,
      editor: ClassicEditor,
      back_up: {
        ngaySua: "2021-10-02T00:00:00",
        ngayTao: "2021-10-02T00:00:00",
      },
      data: {
        ngaySua: "2021-10-02T00:00:00",
        ngayTao: "2021-10-02T00:00:00",
      },
      check_Edit: {
        ngaySua: "2021-10-02T00:00:00",
        ngayTao: "2021-10-02T00:00:00",
      },
      datas1: [],
      datas2: [],
      datas3: [],
      a: "null",
      b: "null1",
      c: "null2",
      data_export: {
        idBaiViet: "",
        ngaySua: "2021-10-02T00:00:00",
        ngayTao: "2021-10-02T00:00:00",
        soSaoTB: 0,
        luotXem: 0,
      },
    };
  },
  created: function () {
    this.List();
  },
  /**
   * Kiểm tra đã đăng nhập hay chưa
   * Date : 10-11-2022
   * Author : Lợn Cọc
   */
  mounted() {
    let user = localStorage.getItem("user-info");
    if (!user) {
      this.$router.push({ path: "/" });
    }
  },
  methods: {
    /**
     * Lấy quảng cáo vào combobox
     * Date : 10-11-2022
     * Author : Lợn Cọc
     */
    LayQuangCao(event) {
      this.data.idQuangCao = event.target.value;
    },
    /**
     * Lấy thể loại vào combobox
     */
    LayTheLoai(event) {
      this.data.idTheLoai = event.target.value;
    },
    /**
     * Lấy nhóm tin
     */
    LayNhomTin(event) {
      this.data.idNhomTin = event.target.value;
    },
    /**
     * Hiển thị nội dung bài viết
     */
    show(value) {
      this.showdetail = true;
      this.content = value;
    },
    /**
     * Đóng nội dung bài viết
     */
    Close() {
      this.showdetail = false;
    },
    /**
     * Gọi Api lấy các dữ liệu cần thiết
     */
    List() {
      try {
        axios.get("https://localhost:44309/api/BaiViet").then((response) => {
          this.datas = response.data;
        });
        axios.get("https://localhost:44309/api/QuangCao").then((response) => {
          this.datas1 = response.data;
        });
        axios.get("https://localhost:44309/api/NhomTinAPI").then((response) => {
          this.datas2 = response.data;
        });
        axios.get("https://localhost:44309/api/TheLoaiAPI").then((response) => {
          this.datas3 = response.data;
        });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Định dạng ngày tháng
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
     *Xóa
     * Date: 6-11-2022
     * Author:Lợn Cọc
     */
    Delete(id) {
      try {
        if (confirm("Bạn chắc chắn muốn xóa?") == true) {
          axios.delete("https://localhost:44309/api/BaiViet/" + id).then(() => {
            alert("Xóa thành công");
            this.List();
          });
        }
      } catch (error) {
        // axios
        //   .get("https://localhost:44309/api/Check_Delete/Check_TheLoai/" + id)
        //   .then((response) => {
        //
        //   });
        console.log(error);
      }
    },
    /**
     * Check xem
     * Date: 6-11-2022
     * Author:Lợn Cọc
     */
    AddOrEdit(value) {
      this.showdialog = true;
      console.log(this.datas1);
      if (value != null) {
        axios
          .get("https://localhost:44309/api/BaiViet/" + value)
          .then((response) => {
            this.data = response.data;
          });
      }
    },
    /**
     * Ấn nút ok
     * Date: 6-11-2022
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
     * Date:6-11-2022
     * Author: Lợn Cọc
     */
    Edit(value) {
      axios
        .get("https://localhost:44309/api/BaiViet/" + value)
        .then((response) => {
          this.check_Edit = response.data;
          if (
            Object.values(this.check_Edit).toString() !=
            Object.values(this.data).toString()
          ) {
            this.GanBien(this.data);
            axios
              .put(
                "https://localhost:44309/api/BaiViet/" + value,
                this.data_export
              )
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
     * Date:6-11-2022
     * Author: Lợn Cọc
     */
    Add() {
      this.GanBien(this.data);
      console.log(this.data_export);
      axios
        .post("https://localhost:44309/api/BaiViet/", this.data_export)
        .then(() => {
          alert("Thêm thành công");
          this.Begin();
          this.List();
        });
    },
    /**
     *
     */
    GanBien(value) {
      this.data_export.idBaiViet = value.idBaiViet;
      this.data_export.idNhomTin = Number(value.idNhomTin);
      this.data_export.idTheLoai = Number(value.idTheLoai);
      this.data_export.idQuangCao = Number(value.idQuangCao);
      this.data_export.tenBaiViet = value.tenBaiViet;
      this.data_export.noiDungBaiViet = value.noiDungBaiViet;
      this.data_export.hinhAnh = value.hinhAnh;
    },
    /**
     * Khởi tạo lại trang thêm hoặc sửa
     * Date:6-11-2022
     * Author: Lợn Cọc
     */
    Begin() {
      this.showdialog = false;
      this.data = this.back_up;
    },
  },
};
</script>
