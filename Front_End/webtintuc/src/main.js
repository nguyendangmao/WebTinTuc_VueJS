import { createApp } from 'vue'
import App from './App.vue'
import $ from "jquery";
import Lib from './public/i18'
import vuerouter from './public/router'
import VueClickAway from "vue3-click-away";
import CKEditor from '@ckeditor/ckeditor5-vue';


createApp(App).use(Lib).use(CKEditor).use($).use(vuerouter).use(VueClickAway).mount('#app')