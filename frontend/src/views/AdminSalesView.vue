<template>
  <Background>
    <NavBarView>
      <AdminSaleList/>
    </NavBarView>
  </Background>
</template>


<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import NavBarView from './NavBarView.vue'
import AdminSaleList from '@/components/sales/AdminSaleList.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBarView,
    AdminSaleList
  },
})
</script>


<style scoped>
</style>