<template>
  <Background>
    <NavBarView>
      <router-link style="text-decoration: none" to="/addSupplierWine">
        <Button class="add-button">Добавить вино</Button>
      </router-link>
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
.add-button {
  display: flex;
  flex-direction: column;
  position: absolute;
  left: 85%;
  bottom: 5%;
}
.external-container {
  align-items: center;
}
</style>