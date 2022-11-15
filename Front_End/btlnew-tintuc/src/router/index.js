import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/Home.vue'
import Contact from '../components/Contact.vue'
import Detail from '../components/Detail.vue'
import NewByCategory from '../components/NewByCategory.vue'
import NewsByGenre from '../components/NewsByGenre.vue'
const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/Contact', name: 'Contact', component: Contact },
    { path: '/Detail/:id', name: 'Detail', component: Detail },
    { path: '/NewByCategory/:id', name: 'NewByCategory', component: NewByCategory },
    { path: '/NewsByGenre/:id', name: 'NewsByGenre', component: NewsByGenre },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router