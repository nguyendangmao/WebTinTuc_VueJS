<template>
 
<Header/>
<router-view/>
<Footer/>

</template>

<script>

import Header from '../src/components/Header.vue'
import Footer from '../src/components/Footer.vue'

export default {
  name: 'App',
  components: {
    Header,Footer
  }
}
</script>

<style  scoped>

</style>
