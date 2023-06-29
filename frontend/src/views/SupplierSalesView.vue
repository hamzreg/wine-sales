<template>
  <Background>
    <NavBarView>
      <SupplierSaleList/>
    </NavBarView>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import NavBarView from './NavBarView.vue'
import SupplierSaleList from '@/components/sales/SupplierSaleList.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBarView,
    SupplierSaleList
  },
})
</script>


<style scoped>
</style>