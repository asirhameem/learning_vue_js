import Vue from 'vue'
import Router from 'vue-router'

import EditUser from '../pages/EditUser.vue'
import About from '../pages/About.vue'
import Contact from '../pages/Contact.vue'
import Welcome from '../pages/Welcome.vue'


Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Welcome',
            component: Welcome

        },
       
        {
            path: '/edit-user/:id',
            name: 'EditUser',
            component: EditUser
        },
        {
            path: '/about',
            name: 'About',
            component: About,
            children:[
            
            {
                path: '/about/contact',
                name: 'Contact',
                component: Contact,
            }
        ]
        }
        
    ]
})