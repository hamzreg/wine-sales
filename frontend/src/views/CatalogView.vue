<template>
  <Background>
    <NavBarView>
      <CatalogList
      v-bind:wineColor="wineColor"
      v-bind:kind="kind"/>
    </NavBarView>
  </Background>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Background from '@/components/background/Background.vue'
import NavBarView from './NavBarView.vue'
import CatalogList from '@/components/catalog/CatalogList.vue'
    
export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    Background,
    NavBarView,
    CatalogList
  },
  props: [
    "wineColor",
    "kind"
  ]
})
</script>


<style scoped>
</style>