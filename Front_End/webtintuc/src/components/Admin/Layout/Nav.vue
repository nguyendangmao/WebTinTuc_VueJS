<template>
  <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
    <div class="profile-sidebar">
      <div class="profile-userpic">
        <img src="../../../assets/logo.png" alt="" />
      </div>
      <div class="profile-usertitle">
        <div class="profile-usertitle-name">ADMIN</div>
        <div class="profile-usertitle-status">
          <span class="indicator label-success"></span>Online
        </div>
      </div>
      <div class="clear"></div>
    </div>
    <div class="divider"></div>
    <ul class="nav menu" style="margin-top: 0px" @click="a($event)">
      <router-link to="/tintuc">
        <li class="router" title="Bài Viết">
          <em class="fa fa-newspaper-o">&nbsp;</em> Bài Viết
        </li>
      </router-link>
      <router-link to="/nhomtin">
        <li class="router" title="Nhóm Tin" value="Nhóm Tin">
          <em class="fa fa-folder">&nbsp;</em>Nhóm tin
        </li>
      </router-link>
      <router-link to="/quangcao">
        <li class="router" title="Quảng Cáo">
          <em class="fa fa-shopping-bag">&nbsp;</em> Quảng Cáo
        </li>
      </router-link>
      <router-link to="/theloai">
        <li class="router" title="Thể Loại">
          <em class="fa fa-bars">&nbsp;</em>Thể loại
        </li>
      </router-link>
      <router-link to="/thongke">
        <li class="router" title="Thống Kê">
          <em class="fa fa-file-text">&nbsp;</em> Thống Kê
        </li>
      </router-link>
      <router-link to="/nguoidung" >
        <li class="router" title="Người Dùng">
          <em class="fa fa-dashboard">&nbsp;</em> Người Dùng
        </li>
      </router-link>
      <router-link to="/">
        <li class="router" @click="logout()" value="">
          <em class="fa fa-power-off">&nbsp;</em> Logout
        </li>
      </router-link>
    </ul>
  </div>
</template>
<script>
export default {
  data() {
    return {
      isActive: false,
      title: "",
    };  
  },
  methods: {
    logout() {
      try {
        if (confirm("Bạn chắc chắn muốn đăng xuất?") == true) {
          this.$emit("Logout", false);
          // this.$router.push("/login");
        } else {
          this.$emit("Logout", true);
        }
      } catch (error) {
        console.log(error);
      }
    },
    a(click) {
      if (click.target.tagName == "LI" && click.target.title != "") {
        this.$emit("daylencha", click.target.title);
      }
    },
  },
};
</script>