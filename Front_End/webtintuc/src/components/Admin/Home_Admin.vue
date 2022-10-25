<template>
    <Header/>
    <Nav/>
    <Content/>
</template>
<script>
import Header from '../Admin/Layout/Header.vue'
import Nav from '../Admin/Layout/Nav.vue'
import Content from '../Admin/Layout/Content.vue'
export default {
  name: 'Admin',
  components: {
    Header,Nav,Content
  }
}
</script>
<style scoped>
@import url(../../assets/css/bootstrap.min.css);
@import url(../../assets/css/font-awesome.min.css);
@import url(../../assets/css/datepicker3.css);
@import url(../../assets/css/styles.css);
</style>