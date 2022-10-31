<template>
    <Header/>
    <Content/>
    <Footer/>
</template>
<script>
import Header from '../User/layout/Header.vue'
import Content from '../User/layout/Content.vue'
import Footer from '../User/layout/Footer.vue'
export default {
  name: 'HomeUser',
  components: {
   Header,Content,Footer
  },
}
</script>