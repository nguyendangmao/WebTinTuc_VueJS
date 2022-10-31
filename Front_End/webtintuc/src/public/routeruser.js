import { createRouter, createWebHistory } from 'vue-router'

import Contact from '../components/User/page/Contact.vue'
import Home from '../components/User/page/Home.vue'
import Detail from '../components/User/page/Detail.vue'

const routes = [
    { path: '/', component: Home },
    { path: '/Contact', component: Contact },
    { path: '/Detail', component: Detail },
]

const routeruser = createRouter({
    history: createWebHistory(),
    routes,
})

export default routeruser