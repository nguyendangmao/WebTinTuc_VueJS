import { createApp } from 'vue'
import App from './App.vue'
import $ from "jquery";
import Lib from './public/i18'
import vuerouter from './public/router'
import axios from "axios";
import moment from "moment";
import routeruser from '../src/public/router'



const app = createApp(App);
app.use(routeruser)
app.use(Lib)
app.use($)
app.use(vuerouter)
app.mount('#app')