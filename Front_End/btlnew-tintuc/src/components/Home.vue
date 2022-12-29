<template>
  <!-- Featured News Slider Start -->
  <div class="container-fluid pt-5 mb-3" autofocus>
    <div class="container">
      <div class="section-title">
        <h4 class="m-0 text-uppercase font-weight-bold">Quảng Cáo</h4>
      </div>
      <div class="owl-carousel news-carousel carousel-item-4 position-relative">
        <div class="position-relative overflow-hidden" style="height: 300px">
          <img v-bind:src="quangcao.hinhAnh" style="width: 100%" />
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

              </div>
            </div>
            <div class="row">
              <div class="col-lg-6" v-for="baiviet in baiviets1" :key="baiviet.idBaiViet">
                <div class="position-relative mb-3">
                  <img class="img-fluid w-100" v-bind:src="baiviet.hinhAnh" style="object-fit: cover" />
                  <div style="text-align: center">
                    <router-link :to="{
                      name: 'Detail',
                      params: { id: baiviet.idBaiViet },
                    }" class="nav-item nav-link">
                      <div style="">{{ baiviet.tenBaiViet }}</div>
                    </router-link>
                  </div>
                  <div style="margin-top:10px">
                    <p style="display: inline">Số sao: {{ baiviet.soSaoTB }}</p>
                    <p style="display: inline;float: right;">Lượt xem: {{ baiviet.luotXem }}</p>
                  </div>
                </div>
              </div>
            </div>

            <div class="col-12">
              <div class="section-title">
                <h4 class="m-0 text-uppercase font-weight-bold">
                  Tin Trong Nước
                </h4>
              </div>
            </div>

            <div class="row">
              <div class="col-lg-6" v-for="baiviet in baiviets4" :key="baiviet.idBaiViet">
                <div class="position-relative mb-3">
                  <img class="img-fluid w-100" v-bind:src="baiviet.hinhAnh" style="object-fit: cover" />
                  <div style="text-align: center">
                    <router-link :to="{
                      name: 'Detail',
                      params: { id: baiviet.idBaiViet },
                    }" class="nav-item nav-link">
                      <div style="">{{ baiviet.tenBaiViet }}</div>
                    </router-link>
                  </div>
                  <div style="margin-top:10px">
                    <p style="display: inline">Số sao: {{ baiviet.soSaoTB }}</p>
                    <p style="display: inline;float: right;">Lượt xem: {{ baiviet.luotXem }}</p>
                  </div>
                </div>
              </div>
            </div>


            <div class="col-12">
              <div class="section-title">
                <h4 class="m-0 text-uppercase font-weight-bold">Tin Nóng</h4>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-6" v-for="baiviet in baiviets" :key="baiviet.idBaiViet">
                <div class="position-relative mb-3">
                  <img class="img-fluid w-100" v-bind:src="baiviet.hinhAnh" style="object-fit: cover" />
                  <div style="text-align: center">
                    <router-link :to="{
                      name: 'Detail',
                      params: { id: baiviet.idBaiViet },
                    }" class="nav-item nav-link">
                      <div style="">{{ baiviet.tenBaiViet }}</div>
                    </router-link>
                  </div>
                  <div style="margin-top:10px">
                    <p style="display: inline">Số sao: {{ baiviet.soSaoTB }}</p>
                    <p style="display: inline;float: right;">Lượt xem: {{ baiviet.luotXem }}</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="col-lg-4">
          <!-- Ads Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">Quảng Cáo</h4>
            </div>
            <div class="bg-white text-center border border-top-0 p-3">
              <img v-bind:src="quangcao.hinhAnh" style="height: 100px; width: 200px" />
            </div>
          </div>
          <!-- Ads End -->

          <!-- Popular News Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">Tin Mới</h4>
            </div>
          </div>

          <div class="row">
            <div class="col-lg-6" v-for="baiviet in baiviets3" :key="baiviet.idBaiViet">
              <div class="position-relative mb-3">
                <img class="img-fluid w-100" v-bind:src="baiviet.hinhAnh" style="object-fit: cover" />
                <div style="text-align: center">
                  <router-link :to="{
                    name: 'Detail',
                    params: { id: baiviet.idBaiViet },
                  }" class="nav-item nav-link">
                    <div style="">{{ baiviet.tenBaiViet }}</div>
                  </router-link>
                </div>
                <!-- <div style="margin-top:10px">
                    <p style="display: inline">Số sao: {{ baiviet.soSaoTB }}</p>
                    <p style="display: inline;float: right;">Lượt xem: {{ baiviet.luotXem }}</p>
                  </div> -->
              </div>
            </div>
          </div>
          <!-- Popular News End -->

          <!-- Tags Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">Nhóm Tin</h4>
            </div>
            <div class="bg-white border border-top-0 p-3">
              <div class="d-flex flex-wrap m-n1">
                <div class="div" v-for="nhomtin in nhomtins" :key="nhomtin.idNhomTin">
                  <router-link :to="{
                    name: 'NewsByGenre',
                    params: { id: nhomtin.idNhomTin },
                  }" class="nav-item nav-link">{{ nhomtin.tenNhomTin }}</router-link>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- News With Sidebar End -->
</template>

<script>
import axios from "axios";
export default {
  name: "Home",
  data() {
    return {
      nhomtins: [],
      baiviets: [],
      baiviets1: [],
      baiviets4: [],
      baiviets3: [],
      quangcao: {},
    };
  },
  created() {
    this.getnhomtins();
    this.getbaiviets();

    this.getbaiviets1();
    this.getbaiviets3();
    this.getbaiviets4();
    this.LayAnhQuangCao();
  },
  props: ["BaiViet"],
  methods: {
    getnhomtins() {
      this.$request
        .get("https://localhost:44309/api/NhomTinAPI")
        .then((res) => {
          this.nhomtins = res.data;
        });
    },
    getbaiviets() {
      this.$request
        .get("https://localhost:44309/api/BaiViet/NewsByGenre?idNhomTin=2")
        .then((res) => {
          this.baiviets = res.data;
        });
    },
    LayAnhQuangCao() {
      axios.get("https://localhost:44309/api/QuangCao/1").then((response) => {
        this.quangcao = response.data;
      });
    },

    getbaiviets1() {
      this.$request
        .get("https://localhost:44309/api/BaiViet/NewsByGenre?idNhomTin=1")
        .then((res) => {
          this.baiviets1 = res.data;
        });
    },

    getbaiviets3() {
      this.$request
        .get("https://localhost:44309/api/BaiViet/NewsByGenre?idNhomTin=3")
        .then((res) => {
          this.baiviets3 = res.data;
        });
    },
    getbaiviets4() {
      this.$request
        .get("https://localhost:44309/api/BaiViet/NewsByGenre?idNhomTin=4")
        .then((res) => {
          this.baiviets4 = res.data;
        });
    },
  },
};
</script>
<style scoped>
@import url(../../src/assets/css/style.css);
</style>