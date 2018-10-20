.class public interface abstract Lcom/igg/sdk/service/IGGLoginService$LoginOperationListener;
.super Ljava/lang/Object;
.source "IGGLoginService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/service/IGGLoginService;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "LoginOperationListener"
.end annotation


# virtual methods
.method public abstract onLoginOperationFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;)V"
        }
    .end annotation
.end method
