<template>
  <div class="row">
    <div
      class="
        col-xs-10
        col-xs-offset-1
        col-sm-8
        col-sm-offset-2
        col-md-4
        col-md-offset-4
      "
    >
      <div class="login-panel panel panel-default">
        <div class="panel-heading">Log in</div>
        <div class="panel-body">
          <div>
            <fieldset>
              <div class="form-group">
                <input
                  class="form-control"
                  v-model="email"
                  placeholder="E-mail"
                  name="email"
                  type="email"
                  autofocus=""
                />
              </div>
              <div class="form-group">
                <input
                  class="form-control"
                  v-model="password"
                  placeholder="Password"
                  name="password"
                  type="password"
                />
              </div>
              <button @click="login" class="btn btn-primary">Login</button>
            </fieldset>
          </div>
        </div>
      </div>
    </div>
    <!-- /.col-->
  </div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      email: "",
      password: "",
    };
  },
  mounted() {
    let user = localStorage.getItem("user-info");
    if (user) {
      this.$router.push({ path: "/tintuc" });
    }
  },
  methods: {
    /**
     * Xử lí khi ấn nút login
     * Author:Lợn cọc
     * Date :25/10/2022 8:49pm
     */
    login() {
      try {
        axios
          .get(
            "https://localhost:44309/api/NguoiDung/LayTaiKhoan?tk=" +
              this.email +
              "&mk=" +
              this.password
          )
          .then((response) => {
            localStorage.setItem("user-info", JSON.stringify(response.data));
            this.$router.push({ path: "/tintuc" });
            // localStorage tồn tại trong 2 phút
            let timerId = setInterval(() => console.log("Đếm"), 1000);
            setTimeout(() => {
              clearInterval(timerId);
              localStorage.clear();
              this.$router.push({ path: "/" });
              alert("Đã kết thúc phiên bản, vui lòng đăng nhập lại");
            }, 120000);
          })
          .catch((e) =>{
            alert(e.response.data);
          })
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>