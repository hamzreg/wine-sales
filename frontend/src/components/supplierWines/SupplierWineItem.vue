<template>
  <div class="supplierWine-item">
    <img src="@/assets/img/wineBottle.svg" height="250"/>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ wine.kind }} {{ wine.color }} {{ wine.sugar }} {{ wine.volume }} л
		</Text>
		<Text font-size="var(--little-text)" color="var(--green-color)">
			{{ supplierWine.price }} ₽
		</Text>
  </div>
</template>
  
  
<script lang="ts">
import { defineComponent } from 'vue'
import Text from '@/components/Text.vue'

import WineInterface from '@/Interfaces/WineInterface'
    
export default defineComponent({
  name: "SupplierWineItem",
  components: {
    Text
  },
  props: {
    supplierWine: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      wine: {
        kind: '',
        color: '',
        sugar: '',
        volume: 0
      }
    }
  },
  mounted() {
    WineInterface.getById(this.supplierWine["wineID"]).then(json => {this.wine = json.data});
  }
})
</script>
  
  
<style scoped>
.supplierWine-item {
  display: grid;
  grid-template-columns: 0.5fr 2fr 0.5fr;
  column-gap: 50px;
  width: 94%;
  padding-top: 2%;
}
</style>