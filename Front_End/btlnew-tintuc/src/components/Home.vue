<template>
<!-- Featured News Slider Start -->
<div class="container-fluid pt-5 mb-3">
    <div class="container">
        <div class="section-title">
            <h4 class="m-0 text-uppercase font-weight-bold">Quảng Cáo</h4>
        </div>
        <div class="owl-carousel news-carousel carousel-item-4 position-relative">
            <div class="position-relative overflow-hidden" style="height: 300px;">
                <img class="img-fluid h-100" src="../../src/assets/../assets/img/news-700x435-1.jpg" style="object-fit: cover;">
                <div class="overlay">
                    <div class="mb-2">
                        <a class="badge badge-primary text-uppercase font-weight-semi-bold p-2 mr-2"
                            href="">Business</a>
                        <a class="text-white" href=""><small>Jan 01, 2045</small></a>
                    </div>
                    <a class="h6 m-0 text-white text-uppercase font-weight-semi-bold" href="">Lorem ipsum dolor sit amet elit...</a>
                </div>
            </div>
        
            
        </div>
    </div>
</div>
<!-- Featured News Slider End -->
<!-- News With Sidebar Start -->
<div class="container-fluid">
    <div class="container">
        <div class="row">
            <div class="col-lg-8">
                <div class="row">
                    <div class="col-12">
                        <div class="section-title">
                            <h4 class="m-0 text-uppercase font-weight-bold">Tin Nổi Bật</h4>
                            <a class="text-secondary font-weight-medium text-decoration-none" href="">View All</a>
                        </div>
                    </div>
                    <div class="row" >
                       
                        <div class="col-lg-6" v-for="baiviet in baiviets" :key="baiviet.idBaiViêt" >
                        <div class="position-relative mb-3" >
                            <img class="img-fluid w-100" v-bind:src="baiviet.hinhAnh" style="object-fit: cover;">
                            <div class="bg-white border border-top-0 p-4">
                                <div class="mb-2">
                                    <a class="badge badge-primary text-uppercase font-weight-semi-bold p-2 mr-2"
                                        href="">Business</a>
                                    <a class="text-body" href=""><small>Jan 01, 2022</small></a>
                                </div>
                                <router-link class="h4 d-block mb-3 text-secondary text-uppercase font-weight-bold" :to="{ name:'product.detail',params: {id:baiviet.idBaiViêt}} "    >{{baiviet.tenBaiViet}}</router-link>
                                <!-- <p class="m-0" :detailBaiViet="baiviet">{{baiviet.noiDungBaiViet}}</p> -->
                            </div>
                            <div class="d-flex justify-content-between bg-white border border-top-0 p-4">
                                <div class="d-flex align-items-center">
                                    <img class="rounded-circle mr-2" src="../assets/img/user.jpg" width="25" height="25" alt="">
                                    <small>John Doe</small>
                                </div>
                                <div class="d-flex align-items-center">
                                    <small class="ml-3"><i class="far fa-eye mr-2"></i>{{baiviet.luotXem}}</small>
                                    <small class="ml-3"><i class="far fa-comment mr-2"></i>123</small>
                                </div>
                            </div>
                        </div>
                    
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-lg-4">
                <!-- Social Follow Start -->
                <div class="mb-3">
                    <div class="section-title mb-0">
                        <h4 class="m-0 text-uppercase font-weight-bold">Theo Dõi Chúng Tôi</h4>
                    </div>
                    <div class="bg-white border border-top-0 p-3">
                        <a href="https://www.facebook.com/" class="d-block w-100 text-white text-decoration-none mb-3" style="background: #39569E;" >
                            <i class="fab fa-facebook-f text-center py-4 mr-3" style="width: 65px; background: rgba(0, 0, 0, .2);"></i>
                            <span class="font-weight-medium">12,345 Fans</span>
                        </a>
                        <a href="https://www.facebook.com/" class="d-block w-100 text-white text-decoration-none mb-3" style="background: #52AAF4;">
                            <i class="fab fa-twitter text-center py-4 mr-3" style="width: 65px; background: rgba(0, 0, 0, .2);"></i>
                            <span class="font-weight-medium">12,345 Followers</span>
                        </a>
                        <a href="https://www.facebook.com/" class="d-block w-100 text-white text-decoration-none mb-3" style="background: #0185AE;">
                            <i class="fab fa-linkedin-in text-center py-4 mr-3" style="width: 65px; background: rgba(0, 0, 0, .2);"></i>
                            <span class="font-weight-medium">12,345 Connects</span>
                        </a>
                       
                    </div>
                </div>
                <!-- Social Follow End -->

                <!-- Ads Start -->
                <div class="mb-3">
                    <div class="section-title mb-0">
                        <h4 class="m-0 text-uppercase font-weight-bold">Quảng Cáo</h4>
                    </div>
                    <div class="bg-white text-center border border-top-0 p-3">
                        <a href=""><img class="img-fluid" src="../assets/img/news-800x500-2.jpg" alt=""></a>
                    </div>
                </div>
                <!-- Ads End -->

                <!-- Popular News Start -->
                <div class="mb-3">
                    <div class="section-title mb-0">
                        <h4 class="m-0 text-uppercase font-weight-bold">Tin Mới</h4>
                    </div>
                    <div class="bg-white border border-top-0 p-3" >
                        <div class="d-flex align-items-center bg-white mb-3" style="height: 110px;">
                            <img class="img-fluid" src="../assets/img/news-110x110-1.jpg" alt="">
                            <div class="w-100 h-100 px-3 d-flex flex-column justify-content-center border border-left-0">
                                <div class="mb-2">
                                    <a class="badge badge-primary text-uppercase font-weight-semi-bold p-1 mr-2" href="">sdsad</a>
                                    <a class="text-body" href=""><small>sdsads</small></a>
                                </div>
                                <a class="h6 m-0 text-secondary text-uppercase font-weight-bold" href="">sdsds</a>
                            </div>
                        </div>
                        
                        <div class="d-flex align-items-center bg-white mb-3" style="height: 110px;">
                            <img class="img-fluid" src="../assets/img/news-110x110-1.jpg" alt="">
                            <div class="w-100 h-100 px-3 d-flex flex-column justify-content-center border border-left-0">
                                <div class="mb-2">
                                    <a class="badge badge-primary text-uppercase font-weight-semi-bold p-1 mr-2" href="">sdsad</a>
                                    <a class="text-body" href=""><small>sdsads</small></a>
                                </div>
                                <a class="h6 m-0 text-secondary text-uppercase font-weight-bold" href="">sdsds</a>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <!-- Popular News End -->

                <!-- Tags Start -->
                <div class="mb-3">
                    <div class="section-title mb-0">
                        <h4 class="m-0 text-uppercase font-weight-bold">Nhóm Tin</h4>
                    </div>
                    <div class="bg-white border border-top-0 p-3"   >
                        <div class="d-flex flex-wrap m-n1">
                            <div class="div"  v-for="nhomtin in nhomtins" :key="nhomtin.idNhomTin">    
                                <a href="" class="btn btn-sm btn-outline-secondary m-1" value="{{nhomtin.idNhomTin}}" >{{nhomtin.tenNhomTin}}</a>    
                            </div>
                        </div>
                    </div>
                </div>

                <!-- <div class="mb-3">
                        <div class="section-title mb-0">
                            <h4 class="m-0 text-uppercase font-weight-bold">Tags</h4>
                        </div>
                        <div class="bg-white border border-top-0 p-3">
                            <div class="d-flex flex-wrap m-n1" >
                                <a href="" class="btn btn-sm btn-outline-secondary m-1">Politics</a>                               
                            </div>
                        </div>
                    </div> -->
                <!-- Tags End -->
            </div>
        </div>
    </div>
</div>
<!-- News With Sidebar End -->
</template>

<script>
export default {
  name: 'Home',
  data(){
    return {
        nhomtins:[],
        baiviets:[]
    }
  },
  created(){
   this.getnhomtins()
   this.getbaiviets()
  },
  props:["BaiViet"],
  methods: {
   
    getnhomtins(){
        this.$request.get('https://localhost:44309/api/NhomTinAPI').then(res => {
            this.nhomtins=res.data
        }) 
    },
    getbaiviets(){
        this.$request.get('https://localhost:44309/api/BaiViet').then(res => {
            this.baiviets=res.data
        }) 
    }
  },

}
</script>
<style scoped>
@import url(../../src/assets/css/style.css);
</style>