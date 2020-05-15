import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import Carousel3d from 'vue-carousel-3d'
import { FormPlugin } from 'bootstrap-vue'
import Autocomplete from '@trevoreyre/autocomplete-vue'
import '@trevoreyre/autocomplete-vue/dist/style.css'
Vue.use(Autocomplete)
Vue.use(FormPlugin )




Vue.config.productionTip = false
Vue.use(Carousel3d)


Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
import './lib/cssLibs';

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

