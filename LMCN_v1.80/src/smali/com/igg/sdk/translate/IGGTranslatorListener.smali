.class public interface abstract Lcom/igg/sdk/translate/IGGTranslatorListener;
.super Ljava/lang/Object;
.source "IGGTranslatorListener.java"


# virtual methods
.method public abstract onFailed(Ljava/util/List;Lcom/igg/sdk/error/IGGError;)V
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;",
            "Lcom/igg/sdk/error/IGGError;",
            ")V"
        }
    .end annotation
.end method

.method public abstract onTranslated(Lcom/igg/sdk/translate/IGGTranslationSet;)V
.end method
