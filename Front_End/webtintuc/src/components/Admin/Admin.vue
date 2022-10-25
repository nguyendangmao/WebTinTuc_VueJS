<template>
    <LoginAdmin @DangNhapvaoAdmin="show" v-if="!Check_login"/>
    <HomeAdmin  v-if="Check_login"
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
    show(login){
        try {
            this.Check_login=login;
        } catch (error) {
            console.log(error);
        }
        
    }
  },
}
</script>