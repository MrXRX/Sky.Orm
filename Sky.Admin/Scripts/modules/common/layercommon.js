var LayerCommonJs = {
    Init: function () {

    },
    LayerOpen: function (content, icon) {
        /*****************
        *icon :
        *0：感叹号
        *1：成功
        *2：失败
        *3：问号
        *4：锁
        *5：不开心
        *6：开心
        ****************/
        parent.layer.open({
            title: "温馨提示",
            content: content || "操作成功",
            icon: icon || 1,
            scrollbar: true,
            time: time,
            btn: "知道了"
        });
    }
}



$(function () {
    LayerCommonJs.Init();
})
