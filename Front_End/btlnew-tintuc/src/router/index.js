import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/Home.vue'
import Contact from '../components/Contact.vue'
import Detail from '../components/Detail.vue'
import NewByCategory from '../components/NewByCategory.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'
const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/Contact', name: 'Contact', component: Contact },
    { path: '/Detail', name: 'Detail', component: Detail },
    { path: '/Detail/:id', name: 'product.detail', component: Detail },
    { path: '/NewByCategory/:id', name: 'NewByCategory', component: NewByCategory },
    { path: '/Login', name: 'Login', component: Login },
    { path: '/Register', name: 'Register', component: Register },

]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router