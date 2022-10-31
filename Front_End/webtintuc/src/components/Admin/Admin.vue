<template>
    <LoginAdmin @DangNhapvaoAdmin="show"
     v-if="!Check_login"/>
    <HomeAdmin  v-if="Check_login"
    @DangNhapvaoAdmin="show"
    />
</template>

<script>
import HomeAdmin from '../Admin/Home_Admin.vue'
import LoginAdmin from '../Admin/Login.vue'

export default {
  name: 'Admin',
  components: {
    HomeAdmin,LoginAdmin
  },
  data() {
    return {
        Check_login: false,
    };
  },
  methods: {
    /**
     * Show trang đăng nhập
     * Author:Lợn Cọc
     * Date: 27/10/2022
     */
    show(login){
        try {
            this.Check_login=login;
            console.log(this.$router.path);
        } catch (error) {
            console.log(error);
        }
        
    }
  },
}
</script>