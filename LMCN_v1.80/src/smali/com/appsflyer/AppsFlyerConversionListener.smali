.class public interface abstract Lcom/appsflyer/AppsFlyerConversionListener;
.super Ljava/lang/Object;
.source ""


# virtual methods
.method public abstract onAppOpenAttribution(Ljava/util/Map;)V
    .annotation build Landroid/support/annotation/WorkerThread;
    .end annotation

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
.end method

.method public abstract onAttributionFailure(Ljava/lang/String;)V
.end method

.method public abstract onInstallConversionDataLoaded(Ljava/util/Map;)V
    .annotation build Landroid/support/annotation/WorkerThread;
    .end annotation

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
.end method

.method public abstract onInstallConversionFailure(Ljava/lang/String;)V
.end method
