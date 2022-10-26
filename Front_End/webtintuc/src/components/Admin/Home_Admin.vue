<template  >
    <Header />
    <Nav @Logout="logout" @daylencha='show'/>
    <Content :title="title" />
</template>
<script>
import Header from '../Admin/Layout/Header.vue'
import Nav from '../Admin/Layout/Nav.vue'
import Content from '../Admin/Layout/Content.vue'
export default {
  name: 'Admin',
  data() {
    return {
      title:'Tin Tức',
    }
  },
  components: {
    Header,Nav,Content
  },
  methods: {
    logout(login){
        try {
            this.$emit("DangNhapvaoAdmin",login);
        } catch (error) {
            console.log(error);
        }
    },
    show(a){
      this.title=a;
    },
    updated() {
      this.show();
    },
  },
}
</script>
<style scoped>
@import url(../../assets/css/bootstrap.min.css);
@import url(../../assets/css/font-awesome.min.css);
@import url(../../assets/css/datepicker3.css);
@import url(../../assets/css/styles.css);
</style>
