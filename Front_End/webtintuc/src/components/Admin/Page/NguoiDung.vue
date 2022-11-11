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
        <li class="active">Người Dùng</li>
      </ol>
    </div>
    <!--/.row-->
    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header" style="color: white; margin-bottom: 0px">
          Người Dùng
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
        style="width: 2000px; max-width: 2000px"
      >
        <thead>
          <tr>
            <th>{{ $t("ID") }}</th>
            <th>Quyền</th>
            <th>{{ $t("TaiKhoan") }}</th>
            <th>{{ $t("MatKhau") }}</th>
            <th>{{ $t("Name") }}</th>
            <th style="text-align: center">{{ $t("GioiTinh") }}</th>
            <th>{{ $t("SDT") }}</th>
            <th style="text-align: center">{{ $t("DateUpdate") }}</th>
            <th>{{ $t("AccUpdate") }}</th>
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
            <td style="text-align: center">{{ format_date(data.ngaySua) }}</td>
            <td>{{ data.nguoiSua }}</td>
            <td>
              <button class="button-6" @click="AddOrEdit(data.id)">Sửa</button>
              <button class="button-6">Tắt Trạng Thái</button>
              <button class="button-8" @click="Check_Delete(data.id)">
                Xóa
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-if="showdialog" class="pop">
      <div class="abc demo">
        <div style="display: flex">
          <div style="padding-right: 10px">
            <label for="tentl" class="LonCoc">Họ và Tên</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              v-model="this.data.hoTen"
              placeholder="Họ và Tên.."
            />
          </div>
          <div style="padding-right: 10px; padding-bottom: 15px">
            <label for="tentl" class="LonCoc">Giới Tính</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              v-model="this.data.gioiTinh"
              placeholder="Giới Tính.."
            />
          </div>
        </div>
        <div style="display: flex">
          <div style="padding-right: 10px; padding-bottom: 15px">
            <label for="tentl" class="LonCoc">Tên tài khoản</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              ref="email"
              v-model="this.data.tenTk"
              placeholder="Tên Tài Khoản...."
            />
            <p style="color: red" v-if="value_user">
              Định dạng email không đúng
            </p>
          </div>
          <div>
            <label for="tentl" class="LonCoc">Mật Khẩu</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              v-model="this.data.matKhau"
              placeholder="Mật Khẩu.."
            />
            <p style="color: red" v-if="matkhau">
              Không được để trống mật khẩu
            </p>
          </div>
        </div>
        <div style="display: flex">
          <div style="padding-right: 10px; padding-bottom: 15px">
            <label for="tentl" class="LonCoc">Phân Quyền</label>
            <br />
            <select @change="LayPhanQuyen($event)" v-model="b">
              <option value="null1" disabled>{{ data.tenQuyen }}</option>
              <option
                v-for="data3 in datas3"
                :key="data3.idPhanQuyen"
                :value="data3.idPhanQuyen"
              >
                {{ data3.tenQuyen }}
              </option>
            </select>
            <p style="color: red" v-if="phanquyen">
              Phải phân quyền cho đối tượng
            </p>
          </div>
          <div>
            <label for="tentl" class="LonCoc">Số điện thoại</label>
            <br />
            <input
              style="margin-left: 5px"
              type="text"
              ref="Phone"
              v-model="this.data.sdt"
              placeholder="Số điện thoại.."
            />
            <p style="color: red" v-if="sdt">
              Số điện thoại phải đúng định dạng
            </p>
          </div>
        </div>
        <div style="float: right">
          <button @click="Confim(this.data.id)" class="button-7">OK</button>
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
  data() {
    return {
      datas: [],
      data: {
        ngayTao: "2022-11-02T14:28:37.796Z",
        nguoiTao: "",
        ngaySua: "2022-11-02T14:28:37.796Z",
      },
      back_up: {
        ngayTao: "2022-11-02T14:28:37.796Z",
        ngaySua: "2022-11-02T14:28:37.796Z",
      },
      check_Edit: {
        id: "",
        idPhanQuyen: "",
        tenQuyen: "",
        gioiTinh: "",
        hoTen: "",
        matKhau: "",
        tenTk: "",
        sdt: "",
        trangThai: "",
        ngayTao: "2022-11-02T14:28:37.796Z",
        nguoiTao: "",
        ngaySua: "2022-11-02T14:28:37.796Z",
        nguoiSua: "",
      },
      data_export: {
        id: "",
        ngaySua: "2021-10-02T00:00:00",
        ngayTao: "2021-10-02T00:00:00",
        trangThai: 0,
      },
      datas3: [],
      b: "null1",
      showdialog: false,
      showtable: true,
      //Khai báo check dữ liệu
      //Phải có Tên tài khoản(chuẩn email)
      value_user: false,
      //Phải có phân quyền
      phanquyen: false,
      //Phải có mật khẩu
      matkhau: false,
      //Số điện thoại phải đúng dạng
      sdt: false,
    };
  },
  created: function () {
    this.List();
  },
  methods: {
    LayPhanQuyen(event) {
      this.data.idPhanQuyen = event.target.value;
    },
    /**
     * Lấy data
     * Date: 4-11-2022
     * Author: Lợn Cọc
     */
    List() {
      try {
        axios.get("https://localhost:44309/api/NguoiDung").then((response) => {
          this.datas = response.data;
        });
        axios
          .get("https://localhost:44309/api/PhanQuyenAPI")
          .then((response) => {
            this.datas3 = response.data;
          });
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Định dạng ngày tháng
     * Date: 4-11-2022
     * Author :Lợn Cọc
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
     * Xóa người dùng
     */
    Check_Delete(id) {
      try {
        axios
          .get("https://localhost:44309/api/Check_Delete/Check_NguoiDung/" + id)
          .then(() => {
            if (confirm("Bạn chắc chắn muốn xóa?") == true) {
              axios
                .delete("https://localhost:44309/api/NguoiDung/" + id)
                .then(() => {
                  alert("Xóa thành công");
                  this.List();
                });
            }
          })
          .catch((error) => {
            if (error.response.data.toString() != "Thỏa mãn") {
              alert(error.response.data);
            }
          });
      } catch (error) {
        alert(error.data);
      }
    },
    /**
     * Check_data
     * Date: 11-11-2022
     * Author : Lợn Cọc
     */
    Check_Data() {
      var CheckEmail = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
      //Phải có Tên tài khoản(chuẩn email)
      if (CheckEmail.test(this.$refs.email.value) == true) {
          this.value_user = false;
        } else this.value_user = true;
      //Phải có phân quyền
      if (this.data_export.idPhanQuyen == Number) this.phanquyen = false;
      else this.phanquyen = true;
      //Phải có mật khẩu
      if (this.data_export.matKhau == undefined) this.matkhau = true;
      else this.matkhau = false;
      //Số điện thoại phải đúng dạng
      var CheckPhone = /((09|03|07|08|05)+([0-9]{8})\b)/g;
      if (CheckPhone.test(this.$refs.Phone.value) == true) {
        this.sdt = false;
      } else this.sdt = true;
    },
    /**
     * Check xem
     * Date: 4-11-2022
     * Author:Lợn Cọc
     */
    AddOrEdit(value) {
      this.showdialog = true;
      if (value != null) {
        axios
          .get("https://localhost:44309/api/NguoiDung/" + value)
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
      console.log(this.data_export);
      this.Check_Data();
      if (value == "" || value == undefined) {
        this.Add();
      } else {
        this.Edit(value);
      }
    },
    /**
     * Xử lí sự kiện sửa
     * Date:4-11-2022
     * Author: Lợn Cọc
     */
    Edit(value) {
      this.GanBien(this.data);
      axios
        .put("https://localhost:44309/api/NguoiDung/" + value, this.data_export)
        .then(() => {
          alert("Sửa thành công");
          this.List();
        });
      this.Begin();

      // .get("https://localhost:44309/api/NguoiDung/" + value)
      // .then((response) => {
      //   this.check_Edit = response.data;
      //   {
      // });
    },
    /**
     * Xử lí sự kiện thêm
     * Date:4-11-2022
     * Author: Lợn Cọc
     */
    Add() {
      console.log(this.data);
      this.GanBien(this.data);
      console.log(this.data_export);
      axios
        .post("https://localhost:44309/api/NguoiDung/", this.data_export)
        .then(() => {
          alert("Thêm thành công");
          this.Begin();
          this.List();
        });
    },
    /**
     * Gán giá trị để thêm hoặc sửa
     * Date: 10-11-2022
     * Author: Lợn Cọc
     */
    GanBien(value) {
      this.data_export.id = value.id;
      this.data_export.idPhanQuyen = Number(value.idPhanQuyen);
      this.data_export.tenTK = value.tenTk;
      this.data_export.matKhau = value.matKhau;
      this.data_export.hoTen = value.gioiTinh;
      this.data_export.sdt = value.sdt;
      this.data_export.gioiTinh = value.gioiTinh;
    },
    /**
     * Khởi tạo lại trang thêm hoặc sửa
     * Date:4-11-2022
     * Author: Lợn Cọc
     */
    Begin() {
      this.showdialog = false;
      this.data = this.back_up;
      this.value_user = false;
      this.phanquyen = false;
      this.matkhau = false;
      this.sdt = false;
    },
  },
};
</script>