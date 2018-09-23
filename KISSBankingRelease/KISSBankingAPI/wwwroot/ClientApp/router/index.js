import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'
import { Form, Button, FormInput, FormSelect, FormGroup, Layout } from 'bootstrap-vue/es/components';

Vue.use(FormGroup);
Vue.use(Layout);
Vue.use(FormSelect);
Vue.use(FormInput);
Vue.use(Button);
Vue.use(Form);
Vue.use(VueRouter)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

let router = new VueRouter({
  mode: 'history',
  routes
})

export default router
