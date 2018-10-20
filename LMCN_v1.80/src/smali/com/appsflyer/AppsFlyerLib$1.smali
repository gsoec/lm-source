.class final Lcom/appsflyer/AppsFlyerLib$1;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Lcom/appsflyer/p$a;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/AppsFlyerLib;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private synthetic ˊ:Ljava/lang/ref/WeakReference;

.field private synthetic ˏ:Lcom/appsflyer/AppsFlyerLib;

.field private synthetic ॱ:Ljava/util/Map;


# direct methods
.method constructor <init>(Lcom/appsflyer/AppsFlyerLib;Ljava/util/Map;Ljava/lang/ref/WeakReference;)V
    .locals 0

    .prologue
    .line 2180
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$1;->ˏ:Lcom/appsflyer/AppsFlyerLib;

    iput-object p2, p0, Lcom/appsflyer/AppsFlyerLib$1;->ॱ:Ljava/util/Map;

    iput-object p3, p0, Lcom/appsflyer/AppsFlyerLib$1;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method private ˋ(Ljava/util/Map;)V
    .locals 3
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 2203
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$1;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 2204
    new-instance v0, Lorg/json/JSONObject;

    invoke-direct {v0, p1}, Lorg/json/JSONObject;-><init>(Ljava/util/Map;)V

    invoke-virtual {v0}, Lorg/json/JSONObject;->toString()Ljava/lang/String;

    move-result-object v1

    .line 2205
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$1;->ˊ:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/content/Context;

    const-string v2, "deeplinkAttribution"

    invoke-static {v0, v2, v1}, Lcom/appsflyer/AppsFlyerLib;->ˊ(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V

    .line 2207
    :cond_0
    return-void
.end method


# virtual methods
.method public final ˋ(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 2190
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 2191
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$1;->ॱ:Ljava/util/Map;

    invoke-direct {p0, v0}, Lcom/appsflyer/AppsFlyerLib$1;->ˋ(Ljava/util/Map;)V

    .line 2192
    invoke-static {}, Lcom/appsflyer/AppsFlyerLib;->ॱ()Lcom/appsflyer/AppsFlyerConversionListener;

    move-result-object v0

    invoke-interface {v0, p1}, Lcom/appsflyer/AppsFlyerConversionListener;->onAttributionFailure(Ljava/lang/String;)V

    .line 2194
    :cond_0
    return-void
.end method

.method public final ˎ(Ljava/util/Map;)V
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    .prologue
    .line 2183
    .line 5197
    invoke-interface {p1}, Ljava/util/Map;->keySet()Ljava/util/Set;

    move-result-object v0

    invoke-interface {v0}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_0
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    .line 5198
    iget-object v2, p0, Lcom/appsflyer/AppsFlyerLib$1;->ॱ:Ljava/util/Map;

    invoke-interface {p1, v0}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v3

    invoke-interface {v2, v0, v3}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0

    .line 2184
    :cond_0
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$1;->ॱ:Ljava/util/Map;

    invoke-direct {p0, v0}, Lcom/appsflyer/AppsFlyerLib$1;->ˋ(Ljava/util/Map;)V

    .line 2185
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$1;->ॱ:Ljava/util/Map;

    invoke-static {v0}, Lcom/appsflyer/AppsFlyerLib;->ˋ(Ljava/util/Map;)V

    .line 2186
    return-void
.end method
