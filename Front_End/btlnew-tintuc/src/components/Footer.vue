<template>
  <div>
    <!-- Footer Start -->
    <div class="container-fluid bg-dark pt-5 px-sm-3 px-md-5 mt-5">
      <div class="row py-4">
        <div class="col-lg-3 col-md-6 mb-5">
          <h5 class="mb-4 text-white text-uppercase font-weight-bold">
            Liên Lạc
          </h5>
          <p class="font-weight-medium">
            <i class="fa fa-map-marker-alt mr-2"></i>225 Quan Hoa_Cầu Giấy_Hà
            Nội
          </p>
          <p class="font-weight-medium">
            <i class="fa fa-phone-alt mr-2"></i>0789227281
          </p>
          <p class="font-weight-medium">
            <i class="fa fa-envelope mr-2"></i>phamtruong13032001@gmail.com
          </p>
        </div>
        <div class="col-lg-3 col-md-6 mb-5">
          <h5 class="mb-4 text-white text-uppercase font-weight-bold">
            Tin Nóng
          </h5>
          <div class="mb-3">
            <div
              class="mb-2"
              v-for="baiviet in baiviets"
              :key="baiviet.idBaiViet"
            >
              <router-link
                :to="{ name: 'Detail', params: { id: baiviet.idBaiViet } }"
                class="nav-item nav-link" style="color:#FFCC00"
                >{{ baiviet.tenBaiViet }}</router-link
              >
            </div>
          </div>
        </div>
        <div class="col-lg-3 col-md-6 mb-5">
          <h5 class="mb-4 text-white text-uppercase font-weight-bold">
            Nhóm Tin
          </h5>
          <div
            class="m-n1"
            v-for="nhomtin in theloais"
            :key="nhomtin.idNhomTin"
          >
            <router-link
              :to="{ name: 'NewsByGenre', params: { id: nhomtin.idNhomTin } }"
              class="btn btn-sm btn-secondary m-1"
              >{{ nhomtin.tenNhomTin }}</router-link
            >
          </div>
        </div>
        <div class="col-lg-3 col-md-6 mb-5">
          <h5 class="mb-4 text-white text-uppercase font-weight-bold">
            Hình ảnh tin tức liên quan
          </h5>
          <div class="row" v-for="baiviet in baiviets" :key="baiviet.idBaiViet">
            <div class="col-4 mb-3">
              <img
                class="w-100"
                v-bind:src="baiviet.hinhAnh"
                v-bind:title="baiviet.tenBaiViet"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- Footer End -->
  </div>
</template>
<script>
export default {
  name: "Header",
  data() {
    return {
      theloais: [],
      baiviets: [],
    };
  },
  created() {
    this.gettheloai();
    this.getbaiviets();
  },
  mounted() {
    let id = this.$route.params.id;
    this.getbaiviets(id);
  },
  methods: {
    gettheloai() {
      this.$request
        .get("https://localhost:44309/api/NhomTinAPI")
        .then((res) => {
          this.theloais = res.data;
        });
    },
    getbaiviets() {
      this.$request.get("https://localhost:44309/api/BaiViet").then((res) => {
        this.baiviets = res.data;
      });
    },
  },
};
</script>
<style scoped>
@import url(../../src/assets/css/style.css);
</style>