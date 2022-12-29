<template>
  <!-- News With Sidebar Start -->
  <div class="container-fluid" autofocus>
    <div class="container">
      <div class="row">
        <div class="col-lg-8">
          <!-- News Detail Start -->
          <div class="position-relative mb-3">
            <div class="bg-white border border-top-0 p-4">
              <div class="mb-3"></div>
              <div v-html="baiviet.noiDungBaiViet"></div>
            </div>
            <div
              class="
                d-flex
                justify-content-between
                bg-white
                border border-top-0
                p-4
              "
            ></div>
          </div>
          <!-- News Detail End -->

          <!-- Comment List Start -->
          <!-- <div class="mb-3">
                        <div class="section-title mb-0">
                            <h4 class="m-0 text-uppercase font-weight-bold">3 Comments</h4>
                        </div>
                        <div class="bg-white border border-top-0 p-4">
                            <div class="media mb-4">
                                <img src="../assets/../assets/img/user.jpg" alt="Image" class="img-fluid mr-3 mt-1" style="width: 45px;">
                                <div class="media-body">
                                    <h6><a class="text-secondary font-weight-bold" href="">John Doe</a> <small><i>01 Jan 2045</i></small></h6>
                                    <p>Diam amet duo labore stet elitr invidunt ea clita ipsum voluptua, tempor labore
                                        accusam ipsum et no at. Kasd diam tempor rebum magna dolores sed sed eirmod ipsum.</p>
                                    <button class="btn btn-sm btn-outline-secondary">Reply</button>
                                </div>
                            </div>
                            <div class="media">
                                <img src="../assets/img/user.jpg" alt="Image" class="img-fluid mr-3 mt-1" style="width: 45px;">
                                <div class="media-body">
                                    <h6><a class="text-secondary font-weight-bold" href="">John Doe</a> <small><i>01 Jan 2045</i></small></h6>
                                    <p>Diam amet duo labore stet elitr invidunt ea clita ipsum voluptua, tempor labore
                                        accusam ipsum et no at. Kasd diam tempor rebum magna dolores sed sed eirmod ipsum.</p>
                                    <button class="btn btn-sm btn-outline-secondary">Reply</button>
                                    <div class="media mt-4">
                                        <img src="../assets/img/user.jpg" alt="Image" class="img-fluid mr-3 mt-1"
                                            style="width: 45px;">
                                        <div class="media-body">
                                            <h6><a class="text-secondary font-weight-bold" href="">John Doe</a> <small><i>01 Jan 2045</i></small></h6>
                                            <p>Diam amet duo labore stet elitr invidunt ea clita ipsum voluptua, tempor
                                                labore accusam ipsum et no at. Kasd diam tempor rebum magna dolores sed sed
                                                eirmod ipsum.</p>
                                            <button class="btn btn-sm btn-outline-secondary">Reply</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div> -->
          <!-- Comment List End -->

          <!-- Comment Form Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">
              bình luận
              </h4>
            </div>
            <div class="bg-white border border-top-0 p-4">
              <form>
                <div class="form-row">
                  <div class="col-sm-6">
                    <div class="form-group">
                      <label for="name">Name *</label>
                      <input type="text" class="form-control" id="name" />
                    </div>
                  </div>
                  <div class="col-sm-6">
                    <div class="form-group">
                      <label for="email">Email *</label>
                      <input type="email" class="form-control" id="email" />
                    </div>
                  </div>
                </div>
                <div class="form-group">
                  <label for="website">Website</label>
                  <input type="url" class="form-control" id="website" />
                </div>

                <div class="form-group">
                  <label for="message">Message *</label>
                  <textarea
                    id="message"
                    cols="30"
                    rows="5"
                    class="form-control"
                  ></textarea>
                </div>
                <div class="form-group mb-0">
                  <input
                    type="submit"
                    value="Leave a comment"
                    class="btn btn-primary font-weight-semi-bold py-2 px-3"
                  />
                </div>
              </form>
            </div>
          </div>
          <!-- Comment Form End -->
        </div>
        <div class="col-lg-4">
          <!-- Social Follow Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">
                Theo dõi chúng tôi
              </h4>
            </div>
          </div>
          <!-- Social Follow End -->

          <!-- Ads Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">Quảng Cáo</h4>
            </div>
            <!-- Ảnh quảng cáo của bài viết đó -->
            <div class="bg-white text-center border border-top-0 p-3">
              <img class="img-fluid" v-bind:src="baiviet.hinhAnhQC" alt="" />
            </div>
          </div>
          <!-- Ads End -->
          <!-- Tags Start -->
          <div class="mb-3">
            <div class="section-title mb-0">
              <h4 class="m-0 text-uppercase font-weight-bold">Tags</h4>
            </div>
            <div class="bg-white border border-top-0 p-3">
              <div class="d-flex flex-wrap m-n1">
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
          <!-- Tags End -->
        </div>
      </div>
    </div>
  </div>
  <!-- News With Sidebar End -->
</template>
<script>
export default {
  name: "Detail",
  data() {
    return {
      baiviet: {},
    };
  },
  created() {
    let id = this.$route.params.id;
    this.getbaiviets(id);
  },
  updated() {
    let id = this.$route.params.id;
    this.getbaiviets(id);
  },
  methods: {
    getbaiviets(id) {
      this.$request
        .get("https://localhost:44309/api/BaiViet/" + id)
        .then((res) => {
          this.baiviet = res.data;
          this.baiviet.luotXem = this.baiviet.luotXem + 1;
          this.Update(id);
        });
    },
    //Tính lượt xem
    Update(id) {
      this.$request
        .put("https://localhost:44309/api/BaiViet/" + id,this.baiviet)
        .then((res) => {
            console.log("Thành công");
        });
    },
  },
};
</script>
<style scoped>
@import url(../../src/assets/css/style.css);
</style>