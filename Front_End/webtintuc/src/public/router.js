import { createRouter, createWebHashHistory } from 'vue-router'

import Tintuc from '../components/Admin/Page/Tintuc'
import NhomTin from '../components/Admin/Page/NhomTin.vue'
import ThongKe from '../components/Admin/Page/ThongKe.vue'
import QuangCao from '../components/Admin/Page/QuangCao.vue'
import TheLoai from '../components/Admin/Page/TheLoai.vue'
import NguoiDung from '../components/Admin/Page/NguoiDung.vue'
import Login from '../components/Admin/Login.vue'
import Home_Admin from '../components/Admin/Admin.vue'

const routes = [


  { path: '/tintuc', component: Tintuc },
  { path: '/nhomtin', component: NhomTin },
  { path: '/thongke', component: ThongKe },
  { path: '/quangcao', component: QuangCao },
  { path: '/theloai', component: TheLoai },
  { path: '/nguoidung', component: NguoiDung },
  { path: '/home', component: Home_Admin },
  { path: '/', component: Login },

]


const vuerouter = createRouter({
  history: createWebHashHistory(),
  routes,
});
// vuerouter.beforeEach((to, from, next) => {
//   const publicPages = ['/login'];
//   const authRequired = !publicPages.includes(to.path);
//   const loggedIn = localStorage.getItem('user');
//   if(authRequired && !loggedIn){
//     return next('/login');
//   }
//   next();
// })
export default vuerouter