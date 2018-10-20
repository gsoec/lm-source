.class final Lcom/appsflyer/AppsFlyerLib$4;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Lcom/appsflyer/AppsFlyerConversionListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/appsflyer/AppsFlyerLib;->getConversionData(Landroid/content/Context;Lcom/appsflyer/ConversionDataListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field private synthetic ˊ:Lcom/appsflyer/AppsFlyerLib;

.field private synthetic ˏ:Lcom/appsflyer/ConversionDataListener;


# direct methods
.method constructor <init>(Lcom/appsflyer/AppsFlyerLib;Lcom/appsflyer/ConversionDataListener;)V
    .locals 0

    .prologue
    .line 1317
    iput-object p1, p0, Lcom/appsflyer/AppsFlyerLib$4;->ˊ:Lcom/appsflyer/AppsFlyerLib;

    iput-object p2, p0, Lcom/appsflyer/AppsFlyerLib$4;->ˏ:Lcom/appsflyer/ConversionDataListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final onAppOpenAttribution(Ljava/util/Map;)V
    .locals 0
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
    .line 1328
    return-void
.end method

.method public final onAttributionFailure(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 1332
    return-void
.end method

.method public final onInstallConversionDataLoaded(Ljava/util/Map;)V
    .locals 1
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
    .line 1319
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$4;->ˏ:Lcom/appsflyer/ConversionDataListener;

    invoke-interface {v0, p1}, Lcom/appsflyer/ConversionDataListener;->onConversionDataLoaded(Ljava/util/Map;)V

    .line 1320
    return-void
.end method

.method public final onInstallConversionFailure(Ljava/lang/String;)V
    .locals 1

    .prologue
    .line 1323
    iget-object v0, p0, Lcom/appsflyer/AppsFlyerLib$4;->ˏ:Lcom/appsflyer/ConversionDataListener;

    invoke-interface {v0, p1}, Lcom/appsflyer/ConversionDataListener;->onConversionFailure(Ljava/lang/String;)V

    .line 1324
    return-void
.end method
