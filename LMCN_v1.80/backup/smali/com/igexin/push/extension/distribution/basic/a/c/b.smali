.class public Lcom/igexin/push/extension/distribution/basic/a/c/b;
.super Lcom/igexin/push/core/bean/BaseAction;


# direct methods
.method public constructor <init>()V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/core/bean/BaseAction;-><init>()V

    return-void
.end method

.method public static a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/a/c/b;
    .locals 3

    const/4 v0, 0x0

    invoke-static {p0}, Landroid/text/TextUtils;->isEmpty(Ljava/lang/CharSequence;)Z

    move-result v1

    if-nez v1, :cond_2

    new-instance v0, Lcom/igexin/push/extension/distribution/basic/a/c/b;

    invoke-direct {v0}, Lcom/igexin/push/extension/distribution/basic/a/c/b;-><init>()V

    new-instance v1, Lorg/json/JSONObject;

    invoke-direct {v1, p0}, Lorg/json/JSONObject;-><init>(Ljava/lang/String;)V

    const-string v2, "actionid"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_0

    const-string v2, "actionid"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/a/c/b;->setActionId(Ljava/lang/String;)V

    :cond_0
    const-string v2, "type"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_1

    const-string v2, "type"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v0, v2}, Lcom/igexin/push/extension/distribution/basic/a/c/b;->setType(Ljava/lang/String;)V

    :cond_1
    const-string v2, "do"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->has(Ljava/lang/String;)Z

    move-result v2

    if-eqz v2, :cond_2

    const-string v2, "do"

    invoke-virtual {v1, v2}, Lorg/json/JSONObject;->getString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/a/c/b;->setDoActionId(Ljava/lang/String;)V

    :cond_2
    return-object v0
.end method
