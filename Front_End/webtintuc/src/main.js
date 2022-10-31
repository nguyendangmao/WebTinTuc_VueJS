import { createApp } from 'vue'
import App from './App.vue'
import $ from "jquery";
import Lib from './public/i18'
import vuerouter from './public/router'
<<<<<<< HEAD
import axios from "axios";
import moment from "moment";
import routeruser from '../src/public/router'
=======

>>>>>>> 52af94ada55641b1a82d854292d3a4f32b1966a0



const app = createApp(App);
app.use(routeruser)
app.use(Lib)
app.use($)
app.use(vuerouter)
app.mount('#app')