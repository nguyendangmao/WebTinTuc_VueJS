<template>
  <!-- Contact Start -->
  <div class="container-fluid mt-5 pt-3" autofocus>
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <div class="bg-white border border-top-0 p-4 mb-3">
            <div class="mb-4">
              <div class="mb-3">
                <div class="d-flex align-items-center mb-2">
                  <i class="fa fa-map-marker-alt text-primary mr-2"></i>
                  <h6 class="font-weight-bold mb-0">Address</h6>
                </div>
                <p class="m-0">72_Đông Sơn_Đông Triều_Quảng Ninh</p>
              </div>
              <div class="mb-3">
                <div class="d-flex align-items-center mb-2">
                  <i class="fa fa-envelope-open text-primary mr-2"></i>
                  <h6 class="font-weight-bold mb-0">Email</h6>
                </div>
                <p class="m-0">phamtruong13032001@gmail.com</p>
              </div>
              <div class="mb-3">
                <div class="d-flex align-items-center mb-2">
                  <i class="fa fa-phone-alt text-primary mr-2"></i>
                  <h6 class="font-weight-bold mb-0">Call</h6>
                </div>
                <p class="m-0">+84 366 690 913</p>
              </div>
            </div>
            <h6 class="text-uppercase font-weight-bold mb-3">Contact Us</h6>
            <form
              method="POST"
              action="https://formspree.io/f/xjvzleng"
              
              @submit="Vaild"
            >
              <div class="form-row">
                <div class="col-md-6">
                  <div class="form-group">
                    <input
                      type="text"
                      class="form-control p-4"
                      placeholder="Your Name"
                      ref="Name"
                      name="Name"
                    />
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <input
                      type="email"
                      class="form-control p-4"
                      placeholder="Your Email"
                      ref="Email"
                      name="Email"
                    />
                  </div>
                </div>
              </div>
              <div class="form-group">
                <textarea
                  class="form-control"
                  rows="4"
                  placeholder="Message"
                  ref="Message"
                  name="Message"
                ></textarea>
              </div>
              <div>
                <button
                  class="btn btn-primary font-weight-semi-bold px-4"
                  style="height: 50px"
                  type="submit"
                >
                  Send Message
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Contact End -->
</template>
<script>
export default {
  methods: {
    Vaild(e) {
      if (this.$refs.Name.value == "") {
        alert("Vui lòng cho biết tên !");
        return ;
      }
      if (this.$refs.Email.value == "") {
        alert("Vui lòng nhập email!");
        return ;
      }
      if (this.$refs.Message.value == "") {
        alert("Vui lòng nhập nội dung phản hồi !");
        return ;
      }
    },
  },
};
</script>
<style scoped>
@import url(../../src/assets/css/style.css);
</style>