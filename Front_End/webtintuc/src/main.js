import { createApp } from 'vue'
import App from './App.vue'
import $ from "jquery";
import Lib from './public/i18'
import vuerouter from './public/router'






createApp(App).use(Lib).use($).use(vuerouter).mount('#app')