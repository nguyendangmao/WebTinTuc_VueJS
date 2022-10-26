import { createApp } from 'vue'
import App from './App.vue'
import {createRouter,createWebHashHistory} from 'vue-router'
import $ from 'jquery'
// import Dashbroad from './components/Admin/Page/Dashbroad.vue'
import Tintuc from './components/Admin/Page/Tintuc.vue'

const routes = [
    // {path :'/dashbroad', component:Dashbroad},
    {path :'/tintuc', component:Tintuc},

  ]
const vuerouter = createRouter({
    history:createWebHashHistory(),
    routes, 
  })

createApp(App).use($).use(vuerouter).mount('#app')