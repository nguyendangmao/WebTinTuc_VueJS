import { createRouter, createWebHashHistory } from 'vue-router'

import Tintuc from '../components/Admin/Page/Tintuc'
import NhomTin from '../components/Admin/Page/NhomTin.vue'
import ThongKe from '../components/Admin/Page/ThongKe.vue'
import QuangCao from '../components/Admin/Page/QuangCao.vue'
import TheLoai from '../components/Admin/Page/TheLoai.vue'
import NguoiDung from '../components/Admin/Page/NguoiDung.vue'

const routes = [
<<<<<<< HEAD
  { path: '/tintuc', component: Tintuc },
  { path: '/nhomtin', component: NhomTin },
  { path: '/thongke', component: ThongKe },
  { path: '/quangcao', component: QuangCao },
  { path: '/theloai', component: TheLoai },
  { path: '/nguoidung', component: NguoiDung },
]
=======
    {path :'/tintuc', component:Tintuc},
    {path :'/nhomtin', component:NhomTin},
    {path :'/thongke', component:ThongKe},
    {path :'/quangcao', component:QuangCao},
    {path :'/theloai', component:TheLoai},
    {path :'/nguoidung', component:NguoiDung},
  ]
>>>>>>> 52af94ada55641b1a82d854292d3a4f32b1966a0
const vuerouter = createRouter({
  history: createWebHashHistory(),
  routes,
})
export default vuerouter