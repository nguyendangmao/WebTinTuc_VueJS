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
        <li class="active">Thống Kê</li>
      </ol>
    </div>
    <!--/.row-->
    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header" style="color: white; margin-bottom: 0px">
          Thống Kê
        </h1>
      </div>
    </div>
    <!--/.row-->
  </div>
</template>

<script>
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
};
</script>