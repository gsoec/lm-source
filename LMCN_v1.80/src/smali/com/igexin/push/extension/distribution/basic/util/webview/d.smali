.class Lcom/igexin/push/extension/distribution/basic/util/webview/d;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/extension/distribution/basic/h/g;


# instance fields
.field final synthetic a:Lcom/igexin/push/core/bean/BaseAction;

.field final synthetic b:Ljava/lang/String;

.field final synthetic c:Ljava/lang/String;

.field final synthetic d:Ljava/lang/String;

.field final synthetic e:I

.field final synthetic f:Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;


# direct methods
.method constructor <init>(Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;Lcom/igexin/push/core/bean/BaseAction;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->f:Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->a:Lcom/igexin/push/core/bean/BaseAction;

    iput-object p3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->b:Ljava/lang/String;

    iput-object p4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->c:Ljava/lang/String;

    iput-object p5, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->d:Ljava/lang/String;

    iput p6, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->e:I

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/core/bean/BaseAction;)V
    .locals 2

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->f:Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->a:Lcom/igexin/push/core/bean/BaseAction;

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/b;

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;Lcom/igexin/push/extension/distribution/basic/b/b;)V

    return-void
.end method

.method public a(Ljava/lang/Exception;)V
    .locals 6

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->a:Lcom/igexin/push/core/bean/BaseAction;

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/b;

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/b/b;->l()I

    move-result v0

    const/4 v1, 0x3

    if-ge v0, v1, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->f:Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->b:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->c:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->d:Ljava/lang/String;

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->a:Lcom/igexin/push/core/bean/BaseAction;

    iget v5, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->e:I

    invoke-virtual/range {v0 .. v5}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->prepareExecuteAction(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/core/bean/BaseAction;I)V

    :goto_0
    return-void

    :cond_0
    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->f:Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/d;->a:Lcom/igexin/push/core/bean/BaseAction;

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/b/b;

    invoke-static {v1, v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/PushWebExtension;Lcom/igexin/push/extension/distribution/basic/b/b;)V

    goto :goto_0
.end method
