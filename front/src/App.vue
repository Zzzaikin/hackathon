<template>
  <v-app>
    <Navbar></Navbar>

    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import Navbar from "./Navbar.vue";
export default {
  name: "App",
  components: {
    Navbar,
  },
  data: () => ({
    //
  }),
};
</script>

<style>
.wrapper {
  width: 100%;
  display: flex;
  justify-content: center;
}
.content {
  width: 1016px;
  display: flex;
  justify-content: center;
}
.v-expansion-panel-content__wrap {
  padding: 0 !important;
}
.v-expansion-panel-header {
  padding-left: 10px !important;
  padding-bottom: 0 !important;
  margin-bottom: 0 !important;
  padding-top: 8px !important;
  min-height: 32px !important;
}
.v-expansion-panels {
  width: 1016px !important;
}
/* canvas {
  width: 1016px !important;
  height: 400px !important;
} */
</style>
