<template>
  <Background>
    <NavBarView>
      <SupplierWineList/>
    </NavBarView>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import NavBarView from './NavBarView.vue'
import SupplierWineList from '@/components/supplierWines/SupplierWineList.vue'
import Button from '@/components/button/Button.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBarView,
    SupplierWineList,
    Button
  },
})
</script>


<style scoped>
</style>