<template>
  <div>
    <table class="table table-bordered" style="width:100%;">
            <thead>
                <tr>
                    <th>{{ $t("ID") }}</th>
                    <th>{{ $t("Name") }}</th>
                    <th>{{ $t("More") }}</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{{}}</td>
                    <td>{{}}</td>
                    <td style="width: 25%">
                      <button class="button-6">Sửa</button>
                      <button class="button-6">Tắt Trạng Thái</button>
                      <button class="button-6">Xóa</button>
                    </td>
                </tr>
            </tbody>
    </table>
  </div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      datas: [],
    }
  },
  created: function () {
    
  },
  methods: {
    
  }
  
}
</script>