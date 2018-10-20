.class public final Lcom/alipay/b/a/a/c/a/b;
.super Ljava/lang/Object;


# direct methods
.method public static a(Lcom/alipay/tscenter/biz/rpc/report/general/model/b;)Lcom/alipay/b/a/a/c/a/c;
    .locals 4

    new-instance v1, Lcom/alipay/b/a/a/c/a/c;

    invoke-direct {v1}, Lcom/alipay/b/a/a/c/a/c;-><init>()V

    if-nez p0, :cond_0

    const/4 v0, 0x0

    :goto_0
    return-object v0

    :cond_0
    iget-boolean v0, p0, Lcom/alipay/tscenter/biz/rpc/report/general/model/b;->a:Z

    iput-boolean v0, v1, Lcom/alipay/b/a/a/c/a/c;->a:Z

    iget-object v0, p0, Lcom/alipay/tscenter/biz/rpc/report/general/model/b;->b:Ljava/lang/String;

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->b:Ljava/lang/String;

    iget-object v2, p0, Lcom/alipay/tscenter/biz/rpc/report/general/model/b;->c:Ljava/util/Map;

    if-eqz v2, :cond_2

    const-string v0, "apdid"

    invoke-interface {v2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->c:Ljava/lang/String;

    const-string v0, "apdidToken"

    invoke-interface {v2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->d:Ljava/lang/String;

    const-string v0, "dynamicKey"

    invoke-interface {v2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->g:Ljava/lang/String;

    const-string v0, "timeInterval"

    invoke-interface {v2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->h:Ljava/lang/String;

    const-string v0, "webrtcUrl"

    invoke-interface {v2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->i:Ljava/lang/String;

    const-string v0, ""

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->j:Ljava/lang/String;

    const-string v0, "drmSwitch"

    invoke-interface {v2, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-static {v0}, Lcom/alipay/b/a/a/a/a;->b(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_2

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v2

    if-lez v2, :cond_1

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const/4 v3, 0x0

    invoke-virtual {v0, v3}, Ljava/lang/String;->charAt(I)C

    move-result v3

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    iput-object v2, v1, Lcom/alipay/b/a/a/c/a/c;->e:Ljava/lang/String;

    :cond_1
    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v2

    const/4 v3, 0x3

    if-lt v2, v3, :cond_2

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const/4 v3, 0x2

    invoke-virtual {v0, v3}, Ljava/lang/String;->charAt(I)C

    move-result v0

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    iput-object v0, v1, Lcom/alipay/b/a/a/c/a/c;->f:Ljava/lang/String;

    :cond_2
    move-object v0, v1

    goto/16 :goto_0
.end method
