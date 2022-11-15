<template>
  <!-- News With Sidebar Start -->
  <div class="container-fluid mt-5 pt-3">
    <div class="container" autofocus>
      <div class="row">
        <div class="col-lg-12">
          <div class="row">
            <div class="col-12">
              <div class="section-title">
                <h4 class="m-0 text-uppercase font-weight-bold">Category</h4>
              </div>
            </div>
            <div
              class="col-lg-6"
              v-for="baiviet in baiviets"
              :key="baiviet.idBaiViet"
            >
              <div class="position-relative mb-3">
                <img
                  class="img-fluid w-100"
                  v-bind:src="baiviet.hinhAnh"
                  style="object-fit: cover"
                />
                <div class="bg-white border border-top-0 p-4">
                  <div class="mb-2">
                    <div style="text-align: center">
                      <router-link
                        :to="{
                          name: 'Detail',
                          params: { id: baiviet.idBaiViet },
                        }"
                        class="nav-item nav-link"
                        ><div>
                          {{ baiviet.tenBaiViet }}
                        </div></router-link
                      >
                    </div>
                    <div style="margin-top: 10px">
                      <p style="display: inline">
                        Số sao: {{ baiviet.soSaoTB }}
                      </p>
                      <p style="display: inline; float: right">
                        Lượt xem: {{ baiviet.luotXem }}
                      </p>
                    </div>
                  </div>
                </div>
                <div 
                  class="
                    d-flex
                    justify-content-between
                    bg-white
                    border border-top-0 
                  "
                  style="width: 554px"
                >
                  <router-link
                    :to="{
                      name: 'NewsByGenre',
                      params: { id: baiviet.idNhomTin },
                    }"
                    class="nav-item nav-link"
                    >{{ baiviet.tenNhomTin }}</router-link
                  >
                  <router-link
                    :to="{
                      name: 'NewByCategory',
                      params: { id: baiviet.idTheLoai },
                    }"
                    class="nav-item nav-link"
                    >{{ baiviet.tenTheLoai }}</router-link
                  >
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
export default {
  name: "newbycategory",
  data() {
    return {
      baiviets: [],
    };
  },
  created() {
    let idtheloai = this.$route.params.id;
    this.getbaiviets(idtheloai);
  },
  updated() {
    if (this.$route.name == "NewsByGenre") {
      this.getbaiviets1(this.$route.params.id);
    } else if (this.$route.name == "NewByCategory") {
      this.getbaiviets(this.$route.params.id);
    }
  },
  methods: {
    getbaiviets(id) {
      this.$request
        .get("https://localhost:44309/api/BaiViet/LayDSbaiviet?idTheLoai=" + id)
        .then((res) => {
          this.baiviets = res.data;
        });
    },
    getbaiviets1(id) {
      this.$request
        .get("https://localhost:44309/api/BaiViet/NewsByGenre?idNhomTin=" + id)
        .then((res) => {
          this.baiviets = res.data;
        });
    },
  },
};
</script>
<style scoped>
@import url(../../src/assets/css/style.css);
</style>