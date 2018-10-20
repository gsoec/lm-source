.class Lcom/igexin/push/extension/distribution/basic/a/t;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/extension/distribution/basic/util/webview/e;


# instance fields
.field final synthetic a:Lcom/igexin/push/extension/distribution/basic/a/s;


# direct methods
.method constructor <init>(Lcom/igexin/push/extension/distribution/basic/a/s;)V
    .locals 0

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/a/t;->a:Lcom/igexin/push/extension/distribution/basic/a/s;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Exception;)V
    .locals 3

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    if-eq p1, v0, :cond_0

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->d:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    if-ne p1, v0, :cond_1

    :cond_0
    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/a/t;->a:Lcom/igexin/push/extension/distribution/basic/a/s;

    invoke-static {v0}, Lcom/igexin/push/extension/distribution/basic/a/s;->a(Lcom/igexin/push/extension/distribution/basic/a/s;)Lcom/igexin/push/extension/distribution/basic/b/o;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "file://"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/b/o;->b(Ljava/lang/String;)V

    const/4 v0, 0x1

    invoke-static {p5, v0}, Lcom/igexin/push/core/g;->a(Ljava/lang/String;Z)I

    move-result v0

    if-nez v0, :cond_1

    :try_start_0
    invoke-static {}, Lcom/igexin/push/core/a/e;->a()Lcom/igexin/push/core/a/e;

    move-result-object v0

    const-string v1, "1"

    invoke-virtual {v0, p5, p6, v1}, Lcom/igexin/push/core/a/e;->a(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Z
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    :cond_1
    :goto_0
    return-void

    :catch_0
    move-exception v0

    goto :goto_0
.end method
