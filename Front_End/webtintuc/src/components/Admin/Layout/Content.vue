<template>
  <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
    <div class="row">
      <ol class="breadcrumb">
        <li>
          <a href="#">
            <em class="fa fa-home"></em>
          </a>
        </li>
        <li class="active">{{ title }}</li>
      </ol>
    </div>
    <!--/.row-->
    <div class="row">
      <div class="col-lg-12">
        <h1 class="page-header" style="color: white; margin-bottom:0px">
          {{ title }}
         
        </h1>
      </div>
    </div>
    <!--/.row-->
    <router-view />
  </div>
</template>

<script>
export default {
  props: ["title"],
  data() {
    return {
      // check:true
    }
  },
  // beforeUpdate() {
  //   if(this.title !="Thống Kê"){
  //     return this.check=true
  //   }else return this.check=false
  // },
  methods: {
    
  },
};
</script>