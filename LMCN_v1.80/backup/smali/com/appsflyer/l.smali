.class final Lcom/appsflyer/l;
.super Ljava/lang/Exception;
.source ""


# direct methods
.method constructor <init>()V
    .locals 1

    .prologue
    .line 11
    const-string v0, "Data was not received from server yet."

    invoke-direct {p0, v0}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    .line 12
    return-void
.end method
