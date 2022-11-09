import { createApp } from 'vue'
import App from './App.vue'
import $ from 'jquery';
import router from '../src/router'
import axios from 'axios'
import VueAxios from 'vue-axios'

const app = createApp(App)
app.use(VueAxios, { $request: axios })
app.use($)
app.use(router)
app.mount('#app')

