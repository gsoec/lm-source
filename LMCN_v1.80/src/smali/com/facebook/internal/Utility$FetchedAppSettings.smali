.class public Lcom/facebook/internal/Utility$FetchedAppSettings;
.super Ljava/lang/Object;
.source "Utility.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/facebook/internal/Utility;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "FetchedAppSettings"
.end annotation


# instance fields
.field private customTabsEnabled:Z

.field private dialogConfigMap:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Lcom/facebook/internal/Utility$DialogFeatureConfig;",
            ">;>;"
        }
    .end annotation
.end field

.field private errorClassification:Lcom/facebook/internal/FacebookRequestErrorClassification;

.field private nuxContent:Ljava/lang/String;

.field private nuxEnabled:Z

.field private sessionTimeoutInSeconds:I

.field private supportsImplicitLogging:Z


# direct methods
.method private constructor <init>(ZLjava/lang/String;ZZILjava/util/Map;Lcom/facebook/internal/FacebookRequestErrorClassification;)V
    .locals 0
    .param p1, "supportsImplicitLogging"    # Z
    .param p2, "nuxContent"    # Ljava/lang/String;
    .param p3, "nuxEnabled"    # Z
    .param p4, "customTabsEnabled"    # Z
    .param p5, "sessionTimeoutInSeconds"    # I
    .param p7, "errorClassification"    # Lcom/facebook/internal/FacebookRequestErrorClassification;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(Z",
            "Ljava/lang/String;",
            "ZZI",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Lcom/facebook/internal/Utility$DialogFeatureConfig;",
            ">;>;",
            "Lcom/facebook/internal/FacebookRequestErrorClassification;",
            ")V"
        }
    .end annotation

    .prologue
    .line 157
    .local p6, "dialogConfigMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/Map<Ljava/lang/String;Lcom/facebook/internal/Utility$DialogFeatureConfig;>;>;"
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 158
    iput-boolean p1, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->supportsImplicitLogging:Z

    .line 159
    iput-object p2, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->nuxContent:Ljava/lang/String;

    .line 160
    iput-boolean p3, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->nuxEnabled:Z

    .line 161
    iput-boolean p4, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->customTabsEnabled:Z

    .line 162
    iput-object p6, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->dialogConfigMap:Ljava/util/Map;

    .line 163
    iput-object p7, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->errorClassification:Lcom/facebook/internal/FacebookRequestErrorClassification;

    .line 164
    iput p5, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->sessionTimeoutInSeconds:I

    .line 165
    return-void
.end method

.method synthetic constructor <init>(ZLjava/lang/String;ZZILjava/util/Map;Lcom/facebook/internal/FacebookRequestErrorClassification;Lcom/facebook/internal/Utility$1;)V
    .locals 0
    .param p1, "x0"    # Z
    .param p2, "x1"    # Ljava/lang/String;
    .param p3, "x2"    # Z
    .param p4, "x3"    # Z
    .param p5, "x4"    # I
    .param p6, "x5"    # Ljava/util/Map;
    .param p7, "x6"    # Lcom/facebook/internal/FacebookRequestErrorClassification;
    .param p8, "x7"    # Lcom/facebook/internal/Utility$1;

    .prologue
    .line 142
    invoke-direct/range {p0 .. p7}, Lcom/facebook/internal/Utility$FetchedAppSettings;-><init>(ZLjava/lang/String;ZZILjava/util/Map;Lcom/facebook/internal/FacebookRequestErrorClassification;)V

    return-void
.end method


# virtual methods
.method public getCustomTabsEnabled()Z
    .locals 1

    .prologue
    .line 180
    iget-boolean v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->customTabsEnabled:Z

    return v0
.end method

.method public getDialogConfigurations()Ljava/util/Map;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Lcom/facebook/internal/Utility$DialogFeatureConfig;",
            ">;>;"
        }
    .end annotation

    .prologue
    .line 188
    iget-object v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->dialogConfigMap:Ljava/util/Map;

    return-object v0
.end method

.method public getErrorClassification()Lcom/facebook/internal/FacebookRequestErrorClassification;
    .locals 1

    .prologue
    .line 192
    iget-object v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->errorClassification:Lcom/facebook/internal/FacebookRequestErrorClassification;

    return-object v0
.end method

.method public getNuxContent()Ljava/lang/String;
    .locals 1

    .prologue
    .line 172
    iget-object v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->nuxContent:Ljava/lang/String;

    return-object v0
.end method

.method public getNuxEnabled()Z
    .locals 1

    .prologue
    .line 176
    iget-boolean v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->nuxEnabled:Z

    return v0
.end method

.method public getSessionTimeoutInSeconds()I
    .locals 1

    .prologue
    .line 184
    iget v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->sessionTimeoutInSeconds:I

    return v0
.end method

.method public supportsImplicitLogging()Z
    .locals 1

    .prologue
    .line 168
    iget-boolean v0, p0, Lcom/facebook/internal/Utility$FetchedAppSettings;->supportsImplicitLogging:Z

    return v0
.end method
