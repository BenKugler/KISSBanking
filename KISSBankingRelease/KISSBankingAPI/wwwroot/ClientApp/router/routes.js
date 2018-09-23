import HomePage from 'components/home-page'
import NewUser from 'components/newuser'
import Account from 'components/account'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'newuser', path: '/newuser', component: NewUser, display: 'Create User', icon: 'list' },
  { name: 'account', path: '/account', component: Account, display: 'Account', icon: 'list' }
]
